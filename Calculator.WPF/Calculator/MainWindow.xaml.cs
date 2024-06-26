
using System;
using System.Windows;
using System.Windows.Controls;


namespace Calculator
{

    public partial class MainWindow : Window
    {
        #region [Private States]
        private string _operation;
        private double _firstNumber;
        private double _secondNumber;
        private bool _resultDisplayed = false;
        private bool _operationClicked = false;
        private bool _errorDisplayed = false;

        #endregion
        #region [Ctor]
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region [OnNumberClick(object sender, RoutedEventArgs e)]
        private void OnNumberClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;


            if (button != null)
            {
                if (_errorDisplayed)
                {
                    Display.Text = button.Content.ToString();
                    _errorDisplayed = false;
                }
                else
                {
                    Display.Text += button.Content;
                    
                }

                _resultDisplayed = false;
                _operationClicked = false;
         

            }
        }
        #endregion

        #region [OnOperationClick(object sender, RoutedEventArgs e)]
        private void OnOperationClick(object sender, RoutedEventArgs e)
        {
            if (_operationClicked)
            {
                Display.Text = "Error: Please enter a new number before selecting an operation";
                _errorDisplayed = true;
                return;
            }
            if (string.IsNullOrEmpty(Display.Text))
            {
                Display.Text = "Error: Please enter a number";
                _errorDisplayed = true;
                return;
            }
            var button = sender as Button;
            if (button != null)
            {
                _operation = button.Content.ToString();
                _firstNumber = double.Parse(Display.Text);
                Display.Clear();
                _operationClicked = true;
                _resultDisplayed = false;
                _errorDisplayed = false;
            }


        }
        #endregion

        #region [OnEqualsClick(object sender, RoutedEventArgs e)]
        private void OnEqualsClick(object sender, RoutedEventArgs e)
        {
            if (_resultDisplayed)
            {
                Display.Text = "Error: Please enter a new number";
                _errorDisplayed = true;
                return;

            }

            if (string.IsNullOrEmpty(Display.Text))
            {
                Display.Text = "Error: Please enter a number";
                _errorDisplayed = true;
                return;
            }
          
            _secondNumber = double.Parse(Display.Text);
            switch (_operation)
            {
                case "+":
                    Display.Text = (_firstNumber + _secondNumber).ToString();
                    break;

                case "-":
                    Display.Text = (_firstNumber - _secondNumber).ToString();
                    break;

                case "*":
                    Display.Text = (_firstNumber * _secondNumber).ToString();
                    break;

                case "/":
                    if (_secondNumber == 0)
                    {
                        Display.Text = "Cannot divide by zero";
                        _errorDisplayed = true;
                        return;
                    }
                    else
                    {
                        Display.Text = (_firstNumber / _secondNumber).ToString();

                    }
                    break;

            }
            _resultDisplayed = true;
            _operationClicked = false;
            _errorDisplayed = false;
        }
        #endregion

        #region [OnClearClick(object sender, RoutedEventArgs e)]
        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            Display.Text = string.Empty;
            _operation = string.Empty;
            _firstNumber = 0.0;
            _secondNumber = 0.0;
            _resultDisplayed = false;
            _operationClicked = false;
            _errorDisplayed = false;
        }
        #endregion

        #region [OnSquareRootClick(object sender, RoutedEventArgs e)]
        private void OnSquareRootClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Display.Text))
            {
                Display.Text = "Error: Please enter a number";
                _errorDisplayed = true;
                return;
            }
            var button = sender as Button;
            if (button != null)
            {
                double result = Math.Sqrt(double.Parse(Display.Text));
                Display.Text = result.ToString();
                _resultDisplayed = true;
                _operationClicked = false;
                _errorDisplayed = false;
            }

        }
        #endregion

        #region [OnPowerOffClick(object sender, RoutedEventArgs e)]
        private void OnPowerOffClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion



    }
}
