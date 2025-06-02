using BookLibrary.Presentation.Model.Interfaces;
using BookLibrary.Presentation.ViewModel.MVVMLight;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BookLibrary.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IModelSublayer modelSublayer;
        private IModelUser? currentUser;
        private ObservableCollection<IModelUser>? users;
        private string actionText = "Random pop-up";
        private string newUserDNI = "";
        private string newUserName = "";

        public MainViewModel() : this(null) { }

#pragma warning disable CS8618
        public MainViewModel(IModelSublayer? modelSublayer)
#pragma warning restore CS8618
        {
            this.modelSublayer = modelSublayer ?? ModelSublayerFactory.CreateModelSublayer();
            Users = new ObservableCollection<IModelUser>(this.modelSublayer.GetAllUsers());

            AddUserCommand = new RelayCommand(async () =>
            {
                await Task.Run(() => this.modelSublayer.AddUser(NewUserDNI, NewUserName));
                Users = new ObservableCollection<IModelUser>(this.modelSublayer.GetAllUsers());
                NewUserName = string.Empty;
                NewUserDNI = string.Empty;
            },
            () => !string.IsNullOrWhiteSpace(NewUserName) && !string.IsNullOrWhiteSpace(NewUserDNI));

            DisplayTextCommand = new RelayCommand(ShowPopupWindow, () => !string.IsNullOrEmpty(ActionText));
        }

        public ICommand AddUserCommand { get; private set; }
        public RelayCommand DisplayTextCommand { get; private set; }

        public ObservableCollection<IModelUser>? Users
        {
            get => users;
            set
            {
                users = value;
                RaisePropertyChanged();
            }
        }

        public IModelUser? CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                RaisePropertyChanged();
            }
        }

        public string ActionText
        {
            get => actionText;
            set
            {
                actionText = value;
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string NewUserName
        {
            get => newUserName;
            set
            {
                newUserName = value;
                RaisePropertyChanged();
                ((RelayCommand)AddUserCommand).RaiseCanExecuteChanged();
            }
        }

        public string NewUserDNI
        {
            get => newUserDNI;
            set
            {
                newUserDNI = value;
                RaisePropertyChanged();
                ((RelayCommand)AddUserCommand).RaiseCanExecuteChanged();
            }
        }

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(ActionText);
        }

        public Action<string> MessageBoxShowDelegate { get; set; } =
            x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the View sublayer");
    }
}
