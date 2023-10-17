using System;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable

namespace Calculator_Task;

public partial class MainWindow : Window
{
    double result;
    double num1 = 0;
    double num2 = 0;
    byte calculateCount = 0;
    bool firstCalculate = true;
    bool isEqualPressed = false;
    string lastOperator;

    public MainWindow()
    {
        InitializeComponent();
    }

    void checkOperatorBtn(string btn)
    {
        if (btn == btnPlus.Content.ToString())
            result = num1 + num2;
        else if (btn == btnCixma.Content.ToString())
            result = num1 - num2;
        else if (btn == btnVurma.Content.ToString())
            result = num1 * num2;
        else if (btn == btnBolme.Content.ToString())
        {
            if (num2 != 0)
                result = num1 / num2;
            else
                MessageBox.Show("Cannot divide by Zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Button? button = sender as Button;
            string? currentContent = DisplayResult.Content.ToString();

            if (isEqualPressed)
            {
                currentContent = "0";
                isEqualPressed = false;
            }

            string? newContent = currentContent == "0" ? button?.Content.ToString() : currentContent + button?.Content;
            DisplayResult.Content = newContent;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    void OperatorButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            isEqualPressed = false;

            calculateCount += 1;
            Button button = sender as Button;
            string currentContent = DisplayResult.Content.ToString();

            if (button == btnEqual)
            {
                calculateCount = 0;
                num2 = double.Parse(currentContent);
                checkOperatorBtn(lastOperator);
                DisplayResult.Content = $"{result}";
                num1 = result;
                num2 = 0;
                isEqualPressed = true;
                return;
            }
            else if (button == btnPlusCixma)
            {
                if (num1 > 0)
                    num1 *= -1;
                else if (num1 < 0)
                    num1 *= 1;
            }

            if (firstCalculate)
            {
                num1 = double.Parse(currentContent);
                firstCalculate = false;
            }

            lastOperator = button.Content.ToString();
            CalculateAndDisplayResult(lastOperator);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    void CalculateAndDisplayResult(string btn)
    {
        try
        {
            string? currentContent = DisplayResult.Content.ToString();
            if (!string.IsNullOrEmpty(currentContent))
            {
                if (calculateCount >= 2)
                {
                    calculateCount = 0;
                    num2 = double.Parse(currentContent);

                    if (btn == btnPlus.Content.ToString())
                        result = num1 + num2;
                    else if (btn == btnCixma.Content.ToString())
                        result = num1 - num2;
                    else if (btn == btnVurma.Content.ToString())
                        result = num1 * num2;
                    else if (btn == btnBolme.Content.ToString())
                    {
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            MessageBox.Show("Cannot divide by Zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    DisplayResult.Content = $"{result}";
                    num1 = result;
                    num2 = 0;
                }
                else
                {
                    DisplayResult.Content = "";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    void btnC_Click(object sender, RoutedEventArgs e)
    {
        DisplayResult.Content = "0";
        num1 = 0;
        num2 = 0;
        calculateCount = 0;
        firstCalculate = true;
        isEqualPressed = false;
    }

    void btnDB_Click(object sender, RoutedEventArgs e)
    {
        num1 = num1 += 0.0;
    }
}
