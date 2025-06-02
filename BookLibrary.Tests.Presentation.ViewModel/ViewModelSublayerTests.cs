using BookLibrary.Presentation.ViewModel;
using BookLibrary.Tests.Presentation.ViewModel.Instrumentation;

namespace BookLibrary.Tests.Presentation.ViewModel
{
    [TestClass]
    public sealed class ViewModelSublayerTests
    {
        [TestMethod]
        public void ActionTextTestMethod()
        {
            MainViewModel _vm = new MainViewModel(new ModelSublayerImplementation());
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            _vm.ActionText = String.Empty;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.IsFalse(_vm.DisplayTextCommand.CanExecute(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }

        [TestMethod]
        public void TextCommandTestMethod()
        {
            MainViewModel _vm = new MainViewModel(new ModelSublayerImplementation());
            int _boxShowCount = 0;
            _vm.MessageBoxShowDelegate = (messageBoxText) =>
            {
                _boxShowCount++;
                Assert.AreEqual<string>("ActionText", messageBoxText);
            };
            _vm.ActionText = "ActionText";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.IsTrue(_vm.DisplayTextCommand.CanExecute(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            _vm.DisplayTextCommand.Execute(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.AreEqual<int>(1, _boxShowCount);
        }

    }
}
