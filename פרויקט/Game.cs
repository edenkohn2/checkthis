// Game.cs
using System.Windows.Controls;
using System.Windows.Threading;
using System;
using System.Windows;
using פרויקט;
using System.Dynamic;

public class Game
{
    private Random random = new Random();
    private int number1;
    private int number2;
    private int correct_answer;
    private int possible1;
    private int possible2;
    private int points = 0;
    private int question_counter = 0;
    private int currentCorrectAnswer;
    public Game(int number1 , int number2 , int correct_answer ,  int points , int question_counter,   int currentCorrectAnswer ) 
    {
        this.number1 = number1;
        this.number2 = number2;
        this.correct_answer = correct_answer;
        ;
        this.points = points;
        this.question_counter = question_counter;
        this.currentCorrectAnswer = currentCorrectAnswer;
       
    }
    public Game()
    {

    }
    public int GetPoints()
    {
        return points;
    }
    private void GenerateNewQuestion()
    {
        number1 = RandomNums1();
        number2 = RandomNums2();
        Get_Operator();

        // Calculate and store the correct answer for the new question
        currentCorrectAnswer = GetCorrectAnswer();
    }

    public int RandomNums1()
    {
        this.number1 = random.Next(1, 11);
        return number1;
    }

    public int RandomNums2()
    {
        this.number2 = random.Next(1, 11);
        return number2;
    }

    public string Get_Operator()
    {
        return random.Next(2) == 0 ? "+" : "-";
    }

    private int GetCorrectAnswer()
    {
        this.number1 = RandomNums1();
        this.number2 = RandomNums2();
        if (Get_Operator() == "+")
        {
            return number1 + number2;
        }
        else
        {
            return number1 - number2;
        }
    }

    public void IsCheckAnswer(int PossibleAns)
    {
        try
        {
            int correctANS = GetCorrectAnswer();

            if (correctANS == PossibleAns)
            {
                this.points += 20;
                MessageBox.Show("Correct");
                NextQuestion();
            }
            else
            {
                if (this.points >= 20) // Ensure points don't go negative
                {
                    this.points -= 20;
                }
                MessageBox.Show("-20 Points :(");
                NextQuestion();
            }
        }
        catch
        {
            MessageBox.Show("Please Enter A Valid Number");
        }
    }
    public bool IsGameFinished()
    {
        return question_counter >= 5;
    }
    private void NextQuestion()
    {
        if (question_counter < 5)
        {
            GenerateNewQuestion();
            question_counter++;
        }
        else
        {
            MessageBox.Show("You've completed all 5 questions!");
            MessageBox.Show("Thank You For Playing!");
            
            
            // Add additional logic for finishing the game
        }
    }




}

    