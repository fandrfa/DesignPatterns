using System;

namespace Strategy
{
    internal abstract class Duck
    {
        internal IQuackBehaviour quackBehaviour;
        internal IFlyBehaviour flyBehaviour;
      
        internal void SetFlyBehaviour(IFlyBehaviour flyBehaviour)
        {
            this.flyBehaviour = flyBehaviour;
        }

        internal void SetQuackBehaviour(IQuackBehaviour quackBehaviour)
        {
            this.quackBehaviour = quackBehaviour;
        }

        internal void Fly()
        {
            flyBehaviour.Fly();
        }

        internal void Quack()
        {
            quackBehaviour.Quack();
        }

        internal abstract void Display();        
    }
}
