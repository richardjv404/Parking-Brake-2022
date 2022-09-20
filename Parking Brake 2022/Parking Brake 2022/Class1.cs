using System;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;

public class Parking_Brake_2022 : Script
{
    private ScriptSettings config;
    private Keys Parking_Brake_Button;
    private bool parkingBrakeOn;
    private bool ParkingBrakeOn = false;
    private bool Parking_Brake_Lights = false;
    private Ped playerPed = Game.Player.Character;
    private Vehicle veh = Game.Player.Character.CurrentVehicle;

    public Parking_Brake_2022()
    {
        Tick += OnTick;
        KeyDown += OnKeyDown;
        ReadINI();
    }

    private void ReadINI()
    {
        config = ScriptSettings.Load("scripts\\Parking Brake 2022.ini");
        Parking_Brake_Button = config.GetValue<Keys>("Options", "Parking_Brake", Keys.B);
        Parking_Brake_Lights = config.GetValue<bool>("Options", "Parking_Brake_Lights", false);
    }

    private void OnTick(object sender, EventArgs e)
    {
        Vehicle veh = Game.Player.Character.CurrentVehicle;
        if (CanWeUse(veh))
        {
            parkingBrakeOn = ParkingBrakeOn;
            if (parkingBrakeOn)
            {
                veh.IsHandbrakeForcedOn = true;
            }

            if (!ParkingBrakeOn)
            {
                veh.IsHandbrakeForcedOn = false;
            }

            bool parking_Brake_Lights = Parking_Brake_Lights;
            if (parking_Brake_Lights)
            {
                parkingBrakeOn = ParkingBrakeOn;
                if (parkingBrakeOn)
                {
                    veh.AreBrakeLightsOn = true;
                }

                bool parkingBrakeOn3 = ParkingBrakeOn;
                if (parkingBrakeOn3)
                {
                    veh.AreBrakeLightsOn = false;
                }
            }
        }
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        ReadINI();
        if (e.KeyCode == Parking_Brake_Button)
        {
            Vehicle veh = Game.Player.Character.CurrentVehicle;
            if (CanWeUse(veh))
            {
                ParkingBrakeOn = !ParkingBrakeOn;
            }
        }
    }
    bool CanWeUse(Entity entity)
    {
        return entity != null && entity.Exists();
    }
}