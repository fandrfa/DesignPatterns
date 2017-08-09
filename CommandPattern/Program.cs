using System;
using System.Collections.Generic;
using System.Linq;
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
            ICommand[] partyOn = new ICommand[] { livingRoomLightOnCommand, garageDoorUpCommand };
            ICommand[] partyOff = new ICommand[] { livingRoomLightOffCommand, garageDoorDownCommand };

            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);

            remoteControl.SetCommand(0, partyOnMacro, partyOffMacro);
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            remoteControl.UndoButtonWasPushed();

            Console.ReadLine();
        }
    }
}
