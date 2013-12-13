using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanServer
{
    class Game
    {
        private List<Player> _guessers = new List<Player>();
        private Player _wordPicker;
        private string _gameWord;
        private List<bool> _guessedLetters = new List<bool>();
        private int attempts=10;
        private decimal _id;

        public decimal Id
        { 
            get { return _id; } 
        }

        public Game(decimal id, List<Player> guessers, Player wordPicker, string gameWord)
        {
            _guessers = guessers;
            _wordPicker = wordPicker;
            _id = id;
            _gameWord = gameWord;

            for (int i = 0; i < _gameWord.Length; i++)
            {
                _guessedLetters.Add(false);
            }

        }
    }
}
