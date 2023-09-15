using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using TicTacToeLernEinheit1.Models;
using static System.Net.Mime.MediaTypeNames; 


public class Program
{
    static TicTacToeGame InitMethods = new TicTacToeGame();
    
    static void Main(string[] args)
    {
        InitMethods.WelcomeScreen();
        InitMethods.InitName();
        InitMethods.InitGame();
    }
    
}
