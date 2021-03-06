/**
 * This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
 * It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)
 */

﻿using UnityEditor;
using UnityEngine;
using System.Collections;
using Rotorz.ReorderableList;
using System.Collections.Generic;

namespace Fungus
{
	
	[CustomEditor (typeof(DialogInput))]
	public class DialogInputEditor : Editor
	{
		protected SerializedProperty clickModeProp;
		protected SerializedProperty nextClickDelayProp;
		protected SerializedProperty keyPressModeProp;
		protected SerializedProperty shiftKeyEnabledProp;
		protected SerializedProperty ignoreMenuClicksProp;
		protected SerializedProperty keyListProp;

		protected virtual void OnEnable()
		{
			clickModeProp = serializedObject.FindProperty ("clickMode");
			nextClickDelayProp = serializedObject.FindProperty ("nextClickDelay");
			keyPressModeProp = serializedObject.FindProperty ("keyPressMode");
			shiftKeyEnabledProp = serializedObject.FindProperty ("shiftKeyEnabled");
			ignoreMenuClicksProp = serializedObject.FindProperty ("ignoreMenuClicks");
			keyListProp = serializedObject.FindProperty ("keyList");
		}
		
		public override void OnInspectorGUI() 
		{
			serializedObject.Update();
			
			DialogInput t = target as DialogInput;

			EditorGUILayout.PropertyField(clickModeProp);
			EditorGUILayout.PropertyField(nextClickDelayProp);
			EditorGUILayout.PropertyField(ignoreMenuClicksProp);

			EditorGUILayout.PropertyField(keyPressModeProp);
			if (t.keyPressMode == DialogInput.KeyPressMode.KeyPressed)
			{
				EditorGUILayout.PropertyField(shiftKeyEnabledProp);
				ReorderableListGUI.Title(new GUIContent("Key List", "Keycodes to check for user input"));
				ReorderableListGUI.ListField(keyListProp);			
			}
				
			serializedObject.ApplyModifiedProperties();
		}		
	}
	
}