namespace Sprint0_OOP2
{
    public class Engine
    {
        public bool isStarted;

        public Engine()
        {
            isStarted = false;
        }

        public string About()
        {
            if (isStarted)
            {
                return this + " is started\n";
            }
            else
            {
                return this + " is not started\n";
            } 
        }

        public void Start()
        {
            isStarted = true;
        }

        public void Stop()
        {
            isStarted = false;
        }
    }
}