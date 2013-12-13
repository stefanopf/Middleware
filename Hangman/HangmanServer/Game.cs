using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanServer
{
    public class Game
    {
        private List<Player> _guessers = new List<Player>();
        private Player _wordPicker;
        private string _gameWord = "";
        private string[] _guessersNames;
        private List<bool> _guessedLetters = new List<bool>();
        private int _attemptsLeft=10;
        private int _id;
        private Server _server;

        public int Id
        { 
            get { return _id; } 
        }

        public Game(int id, List<Player> guessers, Player wordPicker, Server server)
        {
            _guessers = guessers;
            _wordPicker = wordPicker;
            _id = id;
            _server = server;
            _guessersNames = new string[guessers.Count];
            
            for(int i=0;i<guessers.Count;i++)
            {
                _guessersNames[i] = guessers[i].Username;
            }

            int[] wordRange =  new int[2];
            wordRange[0] = 3;
            wordRange[1] = 10; 

            foreach (Player p in _guessers)
            {
                p.Context.startNewGame(_guessersNames, _wordPicker.Username, wordRange, _id);
            }
            _wordPicker.Context.startNewGame(_guessersNames, _wordPicker.Username, wordRange, _id);

        }

        public void setGameWord(string gameWord, string username)
        {
            if (_wordPicker.Username == username)//if its really word picker who is choosing the game word
            {
                _gameWord = gameWord.ToLower();
            }

            for (int i = 0; i < _gameWord.Length; i++)
            {
                _guessedLetters.Add(false);
            }

            foreach (Player p in _guessers)
            {
                p.Context.setWordLength(_gameWord.Length);//notifies all guessers about the lenght of the game word
            }
            _wordPicker.Context.setWordLength(_gameWord.Length);////notifies word picker about the lenght of the game word
        }

        public void guess(string guess, string username)
        {
            try
            {
                Player guesser = _guessers.Find(g => g.Username == username);
                List<int> pos = new List<int>();
                bool isRight = false;

                if (guess.Length == 1)//if player guessed a letter
                {
                    if (_gameWord.Contains(guess.ToLower().ToCharArray()[0]))//if word contains guessed letter
                    {
                        for (int i = 0; i < _gameWord.Length; i++)
                        {
                            if (_gameWord[i] == guess.ToLower().ToCharArray()[0])
                            {
                                pos.Add(i);

                            }
                        }
                        isRight = true;
                    }

                    if (!isRight)//if letter guess was wrong
                        _attemptsLeft--;
                }

                if (guess.Count() > 1)//if player guessed a word
                {
                    if (guess.ToLower() == _gameWord.ToLower())//if word matches
                    {
                        isRight = true;
                    }
                    else
                    {
                        _attemptsLeft -= 2;
                    }
                }

                if (_attemptsLeft <= 0)//if attempts left are gone
                {
                    foreach (Player p in _guessers)
                    {
                        p.Context.endGame(new string[] { _wordPicker.Username }, _gameWord); //notifies all guessers that the game is over and word picker won
                    }
                    _wordPicker.Context.endGame(new string[] { _wordPicker.Username }, _gameWord); //notify word picker that the game is over and word picker won
                }
                else //if there are more attempts left
                {
                    foreach (Player p in _guessers)
                    {
                        p.Context.receiveResult(guess, isRight, pos.ToArray()); //notifies all guessers about the guess result (either word or letter guess)
                        if (guess.Count() > 1 && isRight)
                        {
                            p.Context.endGame(_guessersNames, _gameWord); //in case someone correctly guessed the word, notifies all guessers that the game is over
                        }
                    }
                    _wordPicker.Context.receiveResult(guess, isRight, pos.ToArray()); //notify word picker about the guess result
                    if (guess.Count() > 1 && isRight)//in case someone correctly guessed the word, notifies word picker that the game is over 
                    {
                        _wordPicker.Context.endGame(_guessersNames, _gameWord); //notifies all guessers that the game is over in case someone correctly guessed the word
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not find user \"" + username + "\" in game  \"" + _id + "\" trying to guess a letter");
            }
            
        }

    }
}
