using MauiApp2.Models;
using Syncfusion.Maui.Calendar;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp2;

public partial class MainPage : ContentPage, INotifyPropertyChanged // ✅ 인터페이스 구현
{
    public ObservableCollection<TodoItem> AllTodos { get; set; } = new();
    public ObservableCollection<TodoItem> FilteredTodos { get; set; } = new();

    private DateTime selectedDate = DateTime.Today;

    public DateTime SelectedDate
    {
        get => selectedDate;
        set
        {
            if (selectedDate != value)
            {
                selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                OnPropertyChanged(nameof(SelectedDateText));
                RefreshTodoList();
            }
        }
    }

    public string SelectedDateText => $"{SelectedDate:yyyy년 MM월 dd일} 할 일 목록";

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        RefreshTodoList();
    }

    private void OnDateSelected(object sender, CalendarSelectionChangedEventArgs e)
    {
        if (e.NewValue is DateTime selectedDate)
        {
            SelectedDate = selectedDate;
            OnPropertyChanged(nameof(SelectedDateText));
            RefreshTodoList();
        }
    }

    private void RefreshTodoList()
    {
        FilteredTodos.Clear();
        foreach (var todo in AllTodos.Where(t => t.Date.Date == SelectedDate.Date))
        {
            FilteredTodos.Add(todo);
        }
    }

    private async void AddTodoClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("할 일 추가", "무엇을 할까요?");
        if (!string.IsNullOrWhiteSpace(result))
        {
            AllTodos.Add(new TodoItem
            {
                Title = result,
                IsDone = false,
                Date = SelectedDate
            });
            RefreshTodoList();
        }
    }
}
