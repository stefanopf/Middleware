﻿using System;
using HangmanContract;

namespace HangmanServer
{
    [Serializable]
    class Player
    {
        private string _username;
        private string _password;
        private bool _isOnline;
        private int _totalGuesses;
        private int _correctGuesses;
        IHangmanCallBack _context;

        public int CorrectGuesses
        {
            get { return _correctGuesses; }
            set { _correctGuesses = value; }
        }
        public int TotalGuesses
        {
            get { return _totalGuesses; }
            set { _totalGuesses = value; }
        }
        public string Username
        {
            get { return _username; }
        }
        public string Password
        {
            get { return _password; }
        }
        public bool IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value; }
        }
        public IHangmanCallBack Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public Player(string username, string password)
        {
            this._username = username;
            this._password = password;
            this._isOnline = false;
            this._context = null;
            this._totalGuesses = 0;
            this._correctGuesses = 0;
        }
    }
}
