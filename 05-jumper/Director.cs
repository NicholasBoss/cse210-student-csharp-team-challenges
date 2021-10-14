namespace _05_jumper
{
    class Director
    {
        public bool _keepPlaying;
        public Word _word;
        public Player _player;
        public Display _display;
        public string dashes;

        /// <summary>
        /// Initializes the actors of the game.
        /// </summary>
        public Director()
        {
            _keepPlaying = true;
            _word = new Word();
            _player = new Player();
            _display = new Display();
        }

       public void StartGame()
        {
            _display.CreateParachute();
            _word.ChooseWord();
            // _display.DisplayWord(dashes);
            _display.printParachute();
            while (_keepPlaying)
            {
                
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        public void GetInputs()
        {
            _player.Input();
        }

        public void DoUpdates()
        {
            _display.AddLetter();
            // _display.RemoveLife();
        }

        public void DoOutputs()
        {
            // _display.DisplayWord();
        }
    }
}