using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Clear(this, null);

    }
    double firstNum, secondNum;
    string mathOperator;
    int currentState = 1;


    void Clear(object sender, EventArgs e) {
        firstNum = 0;
        secondNum = 0;
        this.resultLabel.Text = "0";
        currentState = 1;
        this.ClearBtn.Text = "AC";

    }

    void SelectNumber(object sender, EventArgs e) {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.resultLabel.Text == "0" || currentState < 0)
        {
            this.resultLabel.Text = string.Empty;

            if (currentState < 0)
            {
                currentState *= -1;
            }
        }
        this.resultLabel.Text += btnPressed;

        double number;

        if (double.TryParse(this.resultLabel.Text, out number))
        {
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }
        this.ClearBtn.Text = "C";
    }

    void SelectOperator(object sender, EventArgs e) {
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        mathOperator = btnPressed;
    }

    void Calculate(object sender, EventArgs e){
        if (currentState == 2)
        {
            var result = Calculator.Calculate(firstNum, secondNum, mathOperator);
            this.resultLabel.Text = result.ToString();
            firstNum= result;
            currentState = -1;
        }
    }

    void DecimalNumber(object sender, EventArgs e) {
        if (!(this.resultLabel.Text).Contains(","))
        {   
            if(currentState == -1)
            {
                currentState = 1;
            }
            this.resultLabel.Text += ",";
        }

    }

    void Backspace(object sender, EventArgs e) {
        resultLabel.Text = resultLabel.Text.Remove(resultLabel.Text.Length - 1, 1);
        if (resultLabel.Text == "")
        {
            resultLabel.Text = "0";
        }
    }

    void PlusMinus(object sender, EventArgs e) {
        if (currentState < 0)
        {
            currentState *= -1;
        }
        if (currentState == 1)
        {
            var result = Calculator.Calculate(firstNum, -1, "×");
            this.resultLabel.Text = result.ToString();
            firstNum = result;
        }
        else { 
            var result = Calculator.Calculate(-1, secondNum, "×");
            this.resultLabel.Text = result.ToString();
            secondNum = result;
        }
    }


    void Percent(object sender, EventArgs e) {
        if (currentState < 0)
        {
            currentState *= -1;
        }
        if (currentState == 1)
        {
            var result = Calculator.Calculate(firstNum, 100, "÷");
            var resultString = result.ToString();
            decimal d = Decimal.Parse(resultString, System.Globalization.NumberStyles.Float);
            this.resultLabel.Text = d.ToString();
            firstNum = Decimal.ToDouble(d);
        }
        else
        {
            var result = Calculator.Calculate(secondNum, 100, "÷");
            var resultString = result.ToString();
            decimal d = Decimal.Parse(resultString, System.Globalization.NumberStyles.Float);
            this.resultLabel.Text = d.ToString();
            secondNum = Decimal.ToDouble(d);
        }
    }
}






























//void OnNegative(object sender, EventArgs e)
//{
//        //if (currentState == 1)
//        //{
//        //    secondNumber = -1;
//        //    mathOperator = "×";
//        //    currentState = 2;
        //    OnCalculate(this, null);
        //}
        //Button button = (Button)sender;
        //string btnPressed = button.Text;
        //mathOperator = btnPressed;
        //var result = Calculator.Calculate(firstNumber, secondNumber, mathOperator);
        //this.resultText.Text = result.ToString();
        //firstNumber = result;
        //currentState = -1;
        //currentEntry = string.Empty;

//if (currentState == 1)
//{
//    mathOperator = "+/-";
//    currentState = 2;
//    OnCalculate(this, null);

//}






//  private void digit7_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//Result.Text += "7";
//      Clear.Text = "C";
//  }

//  private void digit8_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "8";
//      Clear.Text = "C";

//  }

//  private void digit9_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "9";
//      Clear.Text = "C";
//  }

//  private void digit4_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "4";
//      Clear.Text = "C";
//  }

//  private void digit5_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "5";
//      Clear.Text = "C";
//  }

//  private void digit6_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "6";
//      Clear.Text = "C";
//  }

//  private void digit1_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "1";
//      Clear.Text = "C";
//  }

//  private void digit2_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "2";
//  }

//  private void digit3_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "3";
//      Clear.Text = "C";
//  }

//  private void digit0_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (Result.Text == "0")
//      {
//          Result.Text = "";
//      }
//      Result.Text += "0";
//      Clear.Text = "C";
//  }

//  private void decimalPoint_Clicked(System.Object sender, System.EventArgs e)
//  {
//      if (!(Result.Text).Contains(","))
//      {
//          Result.Text += ",";
//      }
//      Result.Text = Result.Text;
//  }

//private void clear_Clicked(System.Object sender, System.EventArgs e)
//{
//    Result.Text = "0";
//    Clear.Text = "AC";
//}


