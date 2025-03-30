using QueueApp.Models;
using AvaloniaApp.ViewModels;
using System.Windows.Input;
using System;

namespace AvaloniaApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly Queue<string> _queue = new Queue<string>();
    private string _inputText = string.Empty;
    private string _queueState = string.Empty;
    private string _queueItems = string.Empty;

    public string InputText
    {
        get => _inputText;
        set
        {
            if (_inputText != value)
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));

                ((RelayCommand)EnqueueCommand).RaiseCanExecuteChanged();
            }
        }
    }

    public string QueueState
    {
        get => _queueState;
        private set
        {
            _queueState = value;
            OnPropertyChanged(nameof(QueueState));
        }
    }

    public string QueueItems
    {
        get => _queueItems;
        private set
        {
            _queueItems = value;
            OnPropertyChanged(nameof(QueueItems));
        }
    }

    public ICommand EnqueueCommand { get; }
    public ICommand DequeueCommand { get; }
    public ICommand ClearCommand { get; }

    public MainWindowViewModel()
    {
        EnqueueCommand = new RelayCommand(EnqueueItem, () => !string.IsNullOrWhiteSpace(InputText));
        DequeueCommand = new RelayCommand(DequeueItem, () => !_queue.IsEmpty);
        ClearCommand = new RelayCommand(ClearQueue);

        UpdateQueueState();
    }

    public void EnqueueItem()
    {
        if (!string.IsNullOrWhiteSpace(InputText))
        {
            _queue.Enqueue(InputText);
            UpdateQueueState();
            InputText = string.Empty;

            ((RelayCommand)DequeueCommand).RaiseCanExecuteChanged();
        }
    }

    public void DequeueItem()
    {
        if (!_queue.IsEmpty)
        {
            var item = _queue.Dequeue();
            UpdateQueueState();
            QueueState += $"\nИзвлечено: {item}";

            ((RelayCommand)DequeueCommand).RaiseCanExecuteChanged();
        }
        else
        {
            QueueState += "\nОчередь пуста.";
        }
    }

    public void ClearQueue()
    {
        _queue.Clear();
        UpdateQueueState();
        QueueState += "\nОчередь очищена.";

        ((RelayCommand)DequeueCommand).RaiseCanExecuteChanged();
    }

    private void UpdateQueueState()
    {
        QueueState = $"Текущее состояние очереди ({_queue.Count} элементов):";

        QueueItems = string.Join(", ", _queue.GetElements());
    }
}