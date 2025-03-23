using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdapterDesignPattern
{
    public class InputControllerAdapter 
    {
        IPlayerController playerController;
        public InputControllerAdapter(IPlayerController playerController)
        {
            this.playerController = playerController;   
        }


        public void InputMove()
        {
            playerController.Move();
        }

    }

    interface IKeyboardController
    {
        void KeyboardMove();
    }

    interface IGamePadController
    {
        void GamepadMove();
    }

    public class KeyboardController : IKeyboardController
    {
        public void KeyboardMove()
        {
            Debug.Log("Moving with Keyboard");
        }
    }

    public class GamepadController : IGamePadController
    {
        public void GamepadMove()
        {
            Debug.Log("Moving with Gamepad");
        }
    }


    public interface IPlayerController
    {
        void Move();
    }


    public class KeyboardAdapter : IPlayerController
    {
        KeyboardController keyboardController;

        public KeyboardAdapter(KeyboardController keyboardController)
        {
            this.keyboardController = keyboardController;
        }

        public void Move()
        {
            keyboardController.KeyboardMove();
        }

    }


    public class GamepadAdapter : IPlayerController
    {
        GamepadController gamepadController;
        
        public GamepadAdapter(GamepadController gamepadController)
        {
            this.gamepadController = gamepadController;
        }


        public void Move()
        {
            gamepadController.GamepadMove();
        }
    }

}
