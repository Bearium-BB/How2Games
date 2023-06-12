
function appendToTextBox(textInputId, textBoxId) {
    var textInput = document.getElementById(textInputId);
    var textBox = document.getElementById(textBoxId);

    var enteredText = textInput.value;


    // Check if the entered text already exists in the text area
    var existingTags = textBox.value.split(',');
    if (existingTags.includes(enteredText.trim())) {
        textInput.style.animation = 'blink-red 0.5s infinite'; // Apply blinking animation
        setTimeout(function () {
            textInput.style.animation = ''; // Remove animation after 2 seconds
        }, 2000);
        return;
    }

    textBox.value += enteredText + ',';
    textInput.value = '';
}