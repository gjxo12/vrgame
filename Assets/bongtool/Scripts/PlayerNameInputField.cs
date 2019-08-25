﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BongGame
{

    public class PlayerNameInputField : MonoBehaviour
    {

        static string playerNamePrefKey = "PlayerName";

        // Use this for initialization
        void Start()
        {
            string defaultName = "";
            InputField _inputField = this.GetComponent<InputField>();
            if(_inputField != null)
            {
                if(PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setPlayerName(string value)
        {
            PlayerPrefs.SetString(playerNamePrefKey, value);
        }
    }

}
