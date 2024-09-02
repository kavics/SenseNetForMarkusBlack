using SenseNet.Client;

namespace SenseNetForMarkusBlack
{
    internal class ContentView
    {
        private readonly Content _content;
        public ContentView(Content content)
        {
            _content = content;
        }

        public int Id => _content.Id;
        public string Name => _content.Name ?? string.Empty;
        public string Type => _content.Type ?? string.Empty;
    }
}
