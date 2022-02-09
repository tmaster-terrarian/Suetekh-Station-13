using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Maths;
using System;
using Content.Client;
using Content.Shared.PDA;

namespace Content.Client.PDA.Ringer
{
    [GenerateTypedNameReferences]
    public sealed partial class RingtoneMenu : SS14Window
    {
        private string[] _previousNoteInputs = new string[4];

        public RingtoneMenu()
        {
            RobustXamlLoader.Load(this);

            //RingerNoteOneInput
            RingerNoteOneInput.OnTextChanged += _ => //Prevents unauthorized characters from being entered into the LineEdit
            {
                RingerNoteOneInput.Text = RingerNoteOneInput.Text.ToUpper();

                if(!IsNote(RingerNoteOneInput.Text))
                {
                    RingerNoteOneInput.Text = _previousNoteInputs[0];
                }
                else
                {
                    _previousNoteInputs[0] = RingerNoteOneInput.Text;
                }

                RingerNoteOneInput.CursorPosition = RingerNoteOneInput.Text.Length; //Resets caret position to the end of the typed input
            };

            //RingerNoteTwoInput
            RingerNoteTwoInput.OnTextChanged += _ => //Prevents unauthorized characters from being entered into the LineEdit
            {
                RingerNoteTwoInput.Text = RingerNoteTwoInput.Text.ToUpper();

                if(!IsNote(RingerNoteTwoInput.Text))
                {
                    RingerNoteTwoInput.Text = _previousNoteInputs[1];
                }
                else
                {
                    _previousNoteInputs[1] = RingerNoteTwoInput.Text;
                }

                RingerNoteTwoInput.CursorPosition = RingerNoteTwoInput.Text.Length; //Resets caret position to the end of the typed input
            };

            //RingerNoteThreeInput
            RingerNoteThreeInput.OnTextChanged += _ => //Prevents unauthorized characters from being entered into the LineEdit
            {
                RingerNoteThreeInput.Text = RingerNoteThreeInput.Text.ToUpper();

                if(!IsNote(RingerNoteThreeInput.Text))
                {
                    RingerNoteThreeInput.Text = _previousNoteInputs[2];
                }
                else
                {
                    _previousNoteInputs[2] = RingerNoteThreeInput.Text;
                }

                RingerNoteThreeInput.CursorPosition = RingerNoteThreeInput.Text.Length; //Resets caret position to the end of the typed input
            };

            //RingerNoteFourInput
            RingerNoteFourInput.OnTextChanged += _ => //Prevents unauthorized characters from being entered into the LineEdit
            {
                RingerNoteFourInput.Text = RingerNoteFourInput.Text.ToUpper();

                if(!IsNote(RingerNoteFourInput.Text))
                {
                    RingerNoteFourInput.Text = _previousNoteInputs[3];
                }
                else
                {
                    _previousNoteInputs[3] = RingerNoteFourInput.Text;
                }

                RingerNoteFourInput.CursorPosition = RingerNoteFourInput.Text.Length; //Resets caret position to the end of the typed input
            };
        }

        protected override DragMode GetDragModeFor(Vector2 relativeMousePos)
        {
            //Prevents the ringtone window from being resized
            return DragMode.Move;
        }

        /// <summary>
        /// Determines whether or not the characters inputed are authorized
        /// </summary>
        public static bool IsNote(string input)
        {
            input = input.Replace("#", "sharp");

            return Enum.TryParse(input, true, out Note _);
        }
    }
}