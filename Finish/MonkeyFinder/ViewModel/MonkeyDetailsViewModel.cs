namespace MonkeyFinder.ViewModel;

[QueryProperty(nameof(Comment), "comment")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{

    [ObservableProperty]
    Comment comment;

    
}
