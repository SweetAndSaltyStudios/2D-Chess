using System.Collections;

namespace Sweet_And_Salty_Studios
{
    public interface IGame
    {
        IEnumerator ISetup();
        IEnumerator IStartGame();
        IEnumerator IExecuteGame();
        IEnumerator IEndGame();
    }
}