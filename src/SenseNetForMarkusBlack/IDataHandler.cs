using SenseNet.Client;

namespace SenseNetForMarkusBlack;

public enum ConnectionStatus{ Connecting, Connected}
public interface IDataHandler
{
    string Url { get; }
    Task<Content> LoadContentAsync(string path, CancellationToken cancel);
    Task<IContentCollection<Content>> LoadChildren(Content content, CancellationToken cancel);
    Task<ConnectionStatus> CheckConnectionAsync(int timeoutInMilliseconds);
}

internal class RepositoryDataHandler : IDataHandler
{
    private readonly IRepositoryCollection _repositoryCollection;

    public RepositoryDataHandler(IRepositoryCollection repositoryCollection)
    {
        _repositoryCollection = repositoryCollection;
    }

    public string Url => new Lazy<string>(() => _repositoryCollection.GetRepositoryAsync(CancellationToken.None)
        .GetAwaiter().GetResult().Server.Url).Value;

    public async Task<Content> LoadContentAsync(string path, CancellationToken cancel)
    {
        var repository = await _repositoryCollection.GetRepositoryAsync(cancel);

        var content = await repository.LoadContentAsync(new LoadContentRequest
        {
            Path = path,
            Expand = new[] { "Actions" },
            Select = new[] { "Id", "Type", "Path", "Name", "Actions" },
            Parameters = { new KeyValuePair<string, string>("scenario", "ContextMenu") }
        }, cancel);

        return content;
    }

    public async Task<IContentCollection<Content>> LoadChildren(Content content, CancellationToken cancel)
    {
        if (content == null)
            throw new ArgumentNullException(nameof(content));
        if (content.Path == null)
            throw new ArgumentException("Content has no Path");

        var repository = await _repositoryCollection.GetRepositoryAsync(cancel);

        var contents = await repository.LoadCollectionAsync(new()
        {
            Path = content.Path,
            Expand = new[] { "Actions" },
            Select = new[] { "Id", "Type", "Path", "Name", "Actions" },
            OrderBy = new[] { "Name" },
            Parameters = { new KeyValuePair<string, string>("scenario", "ContextMenu") }
        }, cancel);

        return contents;
    }

    public async Task<ConnectionStatus> CheckConnectionAsync(int timeoutInMilliseconds)
    {
        try
        {
            var cancel = new CancellationTokenSource(timeoutInMilliseconds).Token;
            var repo = await _repositoryCollection.GetRepositoryAsync(cancel);
            await repo.IsContentExistsAsync("/Root", cancel);
            return ConnectionStatus.Connected;
        }
        catch (TaskCanceledException e)
        {
            return ConnectionStatus.Connecting;
        }
        catch (OperationCanceledException e)
        {
            return ConnectionStatus.Connecting;
        }
    }
}