using GroupDocs.Parser.Gui.Utils;
using System;

namespace GroupDocs.Parser.Gui.ViewModels
{
    class LogItemViewModel : ViewModelBase
    {
        private readonly DateTime time;
        private readonly string shortMessage;
        private readonly string fullMessage;
        private bool isExpanded;

        public LogItemViewModel(
            DateTime time,
            string message)
        {
            this.time = time;
            var lines = message.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            this.shortMessage = lines[0];
            this.fullMessage = message;

            ExpandCommand = new RelayCommand(() => IsExpanded = !IsExpanded);
        }

        public RelayCommand ExpandCommand { get; private set; }

        public DateTime Time => time;

        public string TimeText => time.ToString();

        public string Message => isExpanded ? fullMessage : shortMessage;

        public string ShortMessage => shortMessage;

        public string FullMessage => fullMessage;

        public bool CanExpand => shortMessage != fullMessage;

        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                if (UpdateProperty(ref isExpanded, value))
                {
                    NotifyPropertyChanged(nameof(Message));
                }
            }
        }
    }
}
