using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavourial_State
{
    //Client
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.BulletHit(3);
            player.BulletHit(9);
            player.BulletHit(12);

            Console.ReadLine();
        }

        //'Context' class: accessed by the client
        public class Player
        {
            State currentState;

            //Concrete state object that changes its state
            public Player()
            {
                this.currentState = new HealthyState();
            }

            public void BulletHit(int bullets)
            {
                Console.WriteLine("Bullet hits to the player: " + bullets);
                if (bullets < 5)
                    this.currentState = new HealthyState();
                if (bullets >= 5 && bullets < 10)
                    this.currentState = new HurtState();
                if (bullets >= 10)
                    this.currentState = new DeadState();

                currentState.ExecuteCommand(this);
            }
        }
        //'State: interface which defines the behaviour associated with a state of the context object
        public interface State
        {
            void ExecuteCommand(Player player);
        }
        //'ConcreteStateA' class which implements 'State' interface
        //Each concrete state class implements a behavior associated with a state of context
        public class HealthyState : State
        {
            public void ExecuteCommand(Player player)
            {
                Console.WriteLine("The player is in Healthy State.");
            }
        }
        //'ConcreteStateB' class which implements 'State' interface
        //Each concrete state class implements a behavior associated with a state of context
        public class HurtState : State
        {
            public void ExecuteCommand(Player player)
            {
                Console.WriteLine("The player is wounded. Please search health points");
            }
        }
        //'ConcreteStateC' class which implements 'State' interface
        //Each concrete state class implements a behavior associated with a state of context
        public class DeadState : State
        {
            public void ExecuteCommand(Player player)
            {
                Console.WriteLine("The player is dead. Game Over.");
            }
        }
    }
}