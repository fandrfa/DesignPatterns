using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();

            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            CeilingFan livingRoomCeilingFan = new CeilingFan("Living Room");
            GarageDoor garageDoor = new GarageDoor();            
            Stereo livingRoomStereo = new Stereo("Living Room");
                        
            LightOnCommand livingRoomLightOnCommand = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOffCommand = new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOnCommand = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOffCommand = new LightOffCommand(kitchenLight);

            CeilingFanOnCommand livingRoomCeilingFanOnCommand = new CeilingFanOnCommand(livingRoomCeilingFan);
            CeilingFanOffCommand livingRoomCeilingFanOffCommand = new CeilingFanOffCommand(livingRoomCeilingFan);

            GarageDoorUpCommand garageDoorUpCommand = new GarageDoorUpCommand(garageDoor);
            GarageDoorDownCommand garageDoorDownCommand = new GarageDoorDownCommand(garageDoor);

            StereoWithCDCommand livingRoomStereoWithCDCommand = new StereoWithCDCommand(livingRoomStereo);
            StereoOffCommand livingRoomStereoOffCommand = new StereoOffCommand(livingRoomStereo);

            // MAIN
            //remoteControl.SetCommand(0, livingRoomLightOnCommand, livingRoomLightOffCommand);
            //remoteControl.SetCommand(1, kitchenLightOnCommand, kitchenLightOffCommand);
            //remoteControl.SetCommand(2, livingRoomCeilingFanOnCommand, livingRoomCeilingFanOffCommand);
            //remoteControl.SetCommand(3, livingRoomStereoWithCDCommand, livingRoomStereoOffCommand);

            //Console.WriteLine(remoteControl.ToString());

            //Console.ReadLine();

            //remoteControl.OnButtonWasPushed(0);
            //remoteControl.OffButtonWasPushed(0);
            //remoteControl.OnButtonWasPushed(1);
            //remoteControl.OffButtonWasPushed(1);
            //remoteControl.OnButtonWasPushed(2);
            //remoteControl.OffButtonWasPushed(2);
            //remoteControl.OnButtonWasPushed(3);
            //remoteControl.OffButtonWasPushed(3);

            //Console.ReadLine();

            // UNDO 
            //remoteControl.SetCommand(0, livingRoomLightOnCommand, livingRoomLightOffCommand);
            //remoteControl.OnButtonWasPushed(0);
            //remoteControl.OffButtonWasPushed(0);
            //Console.WriteLine(remoteControl.ToString());
            //remoteControl.UndoButtonWasPushed();
            //remoteControl.OffButtonWasPushed(0);
            //remoteControl.OnButtonWasPushed(0);
            //Console.WriteLine(remoteControl.ToString());
            //remoteControl.UndoButtonWasPushed();

            //CeilingFanMediumCommand ceilingFanMedium = new CeilingFanMediumCommand(livingRoomCeilingFan);
            //CeilingFanHighCommand ceilingFanHigh = new CeilingFanHighCommand(livingRoomCeilingFan);
            //CeilingFanOffCommand ceilingFanOff = new CeilingFanOffCommand(livingRoomCeilingFan);

            //remoteControl.SetCommand(0, ceilingFanMedium, ceilingFanOff);
            //remoteControl.SetCommand(1, ceilingFanHigh, ceilingFanOff);
            //remoteControl.OnButtonWasPushed(0);
            //remoteControl.OffButtonWasPushed(0);
            //remoteControl.UndoButtonWasPushed();
            //remoteControl.OnButtonWasPushed(1);            
            //remoteControl.UndoButtonWasPushed();        
            //Console.ReadLine();

            // MACRO COMMAND
            Command[] partyOn = new Command[] { livingRoomLightOnCommand, garageDoorUpCommand };
            Command[] partyOff = new Command[] { livingRoomLightOffCommand, garageDoorDownCommand };

            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);

            remoteControl.SetCommand(0, partyOnMacro, partyOffMacro);
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            remoteControl.UndoButtonWasPushed();

            Console.ReadLine();
        }
    }

    public interface Command
    {
        void Execute();
        void Undo();
    }

    internal class MacroCommand : Command
    {
        private Command[] commands;

        public MacroCommand(Command[] commands)
        {
            this.commands = commands;
        }

        public void Execute()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            foreach (var command in commands)
            {
                command.Undo();
            }
        }
    }
    
    internal sealed class NoCommand : Command
    {
        public void Execute()
        {            
        }

        public void Undo()
        {            
        }
    }

    internal sealed class SimpleRemoteControl
    {
        private Command slot;
        public SimpleRemoteControl()
        {

        }
        public void SetCommand(Command command)
        {
            slot = command;
        }
        public void ButtonWasPressed()
        {
            slot.Execute();
        }
    }

    internal sealed class RemoteControl
    {
        private int numberOfSlots = 7;
        private Command[] onCommands;
        private Command[] offCommands;
        private Command undoCommand;

        public RemoteControl()
        {
            onCommands = new Command[numberOfSlots];
            offCommands = new Command[numberOfSlots];
            NoCommand noCommand = new NoCommand();

            for (int i = 0; i < numberOfSlots; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }

            undoCommand = noCommand;
        }

        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].Execute();
            undoCommand = onCommands[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].Execute();
            undoCommand = offCommands[slot];
        }

        public void UndoButtonWasPushed()
        {            
            undoCommand.Undo();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfSlots; i++)
            {
                sb.Append("Slot # " + i + ": On = " + onCommands[i].GetType().ToString() + ", Off = " + offCommands[i].GetType().ToString() + Environment.NewLine);
            }

            sb.Append("Undo command = " + undoCommand.GetType().ToString());

            return sb.ToString();
        }
    }

    internal sealed class Light
    {
        private string room;

        public Light(string room)
        {
            this.room = room;
        }

        public void On()
        {
            Console.WriteLine("{0} Light is on!", room);
        }

        public void Off()
        {
            Console.WriteLine("{0} Light is off!", room);
        }
    }

    internal sealed class LightOnCommand : Command
    {
        private Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.On();
        }

        public void Undo()
        {
            light.Off();
        }
    }

    internal sealed class LightOffCommand : Command
    {
        private Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.Off();
        }

        public void Undo()
        {
            light.On();
        }
    }

    internal sealed class GarageDoor
    {
        public void Up()
        {
            Console.WriteLine("The door is opened");
        }

        public void Down()
        {
            Console.WriteLine("The door is closed");
        }

        public void Stop()
        {
            Console.WriteLine("The door is stopped");
        }

        public void LightOn()
        {
            Console.WriteLine("The light is on");
        }

        public void LightOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    internal sealed class GarageDoorUpCommand : Command
    {
        GarageDoor garageDoor;
        public GarageDoorUpCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Up();
        }

        public void Undo()
        {
            garageDoor.Down();
        }
    }

    internal sealed class GarageDoorDownCommand : Command
    {
        GarageDoor garageDoor;
        public GarageDoorDownCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Down();
        }

        public void Undo()
        {
            garageDoor.Up();
        }
    }

    internal sealed class GarageDoorStopCommand : Command
    {
        GarageDoor garageDoor;
        public GarageDoorStopCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.Up();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class Stereo
    {
        private string room;
        private float volume;

        public Stereo(string room)
        {
            this.room = room;
        }

        public void On()
        {
            Console.WriteLine("{0} Stereo is on", room);
        }

        public void Off()
        {
            Console.WriteLine("{0} Stereo is off", room);
        }

        public void SetCD()
        {
            Console.WriteLine("{0} The mode is set on CD", room);
        }

        public void SetRadio()
        {
            Console.WriteLine("0} The mode is set on Radio", room);
        }

        public void SetDVD()
        {
            Console.WriteLine("0} The mode is set on DVD", room);
        }

        public void SetVolume(float volume)
        {
            this.volume = volume;            
        }
    }

    internal class StereoWithCDCommand : Command
    {
        private Stereo stereo;

        public StereoWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void Execute()
        {
            stereo.On();
            stereo.SetCD();
            stereo.SetVolume(11);
        }

        public void Undo()
        {
            stereo.Off();
        }
    }

    internal class StereoOnCommand : Command
    {
        private Stereo stereo;

        public StereoOnCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void Execute()
        {
            stereo.On();            
        }

        public void Undo()
        {
            stereo.Off();
        }
    }

    internal class StereoOffCommand : Command
    {
        private Stereo stereo;

        public StereoOffCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void Execute()
        {
            stereo.Off();
        }

        public void Undo()
        {
            stereo.On();
        }
    }

    internal sealed class CeilingFan
    {
        public static int HIGH = 3;
        public static int MEDIUM = 2;
        public static int LOW = 1;
        public static int OFF = 0;

        private int speed;
        private string room;

        public CeilingFan(string room)
        {
            this.room = room;
            speed = OFF;
        }

        public void On()
        {
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);
        }

        public void Off()
        {
            speed = OFF;
            Console.WriteLine("{0} Ceiling Fan is off!", room);
        }

        public void High()
        {
            speed = HIGH;
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);            
        }

        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);            
        }

        public void Low()
        {            
            speed = LOW;
            Console.WriteLine("{0} Ceiling Fan is on, speed = {1}", room, speed);
        }

        public int GetSpeed()
        {
            return speed;
        }
    }

    internal sealed class CeilingFanOnCommand : Command
    {
        private CeilingFan ceilingFan;
        public CeilingFanOnCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            ceilingFan.On();
        }

        public void Undo()
        {
            ceilingFan.Off();
        }
    }

    internal sealed class CeilingFanOffCommand : Command
    {
        private CeilingFan ceilingFan;
        private int previousSpeed;

        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {            
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetSpeed();
            ceilingFan.Off();
        }

        public void Undo()
        {            
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }

    internal sealed class CeilingFanHighCommand : Command
    {
        private CeilingFan ceilingFan;
        private int previousSpeed;

        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetSpeed();
            ceilingFan.High();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }

    internal sealed class CeilingFanMediumCommand : Command
    {
        private CeilingFan ceilingFan;
        private int previousSpeed;

        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetSpeed();
            ceilingFan.Medium();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }

    internal sealed class CeilingFanLowCommand : Command
    {
        private CeilingFan ceilingFan;
        private int previousSpeed;

        public CeilingFanLowCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void Execute()
        {
            previousSpeed = ceilingFan.GetSpeed();
            ceilingFan.Low();
        }

        public void Undo()
        {
            if (previousSpeed == CeilingFan.HIGH)
            {
                ceilingFan.High();
            }
            if (previousSpeed == CeilingFan.MEDIUM)
            {
                ceilingFan.Medium();
            }
            if (previousSpeed == CeilingFan.LOW)
            {
                ceilingFan.Low();
            }
            if (previousSpeed == CeilingFan.OFF)
            {
                ceilingFan.Off();
            }
        }
    }
}
