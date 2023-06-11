document.getElementById('fileInput').addEventListener('change', function () {
    console.log("File Selected");
    var fileInput = this;
    var file = fileInput.files[0];

    if (file) {
        var formData = new FormData();
        formData.append('file', file);
        var fileName = generateGuid()
        var imgElement = document.createElement('img');
        var fileName = generateGuid();
        imgElement.src = "/Images/" + fileName;

        var imageContainer = document.getElementById('post');
        imageContainer.appendChild(imgElement);

        fetch('/Posts/UploadFile', {
            method: 'POST',
            body: JSON.stringify({ fileName: fileName, file: file })
        })

        .then(function (response) {
            if (response.ok) {
                console.log('File uploaded successfully.');
                // Perform any additional actions on success if needed
            } else {
                console.error('File upload failed.');
                // Handle the error if needed
            }
        })
        .catch(function (error) {
            console.error(error);
            // Handle the error if needed
        });
    }
});


//when one of the selects is changed
function SelectChange(element) {
    //highlighted text
    var selection = window.getSelection();

    //content editable div
    const textBox = document.getElementById("text");

    //span element to wrap highlighted text
    const span = document.createElement("span");

    var range = selection.getRangeAt(0);

    // Create a temporary container element to hold the range content
    var container = document.createElement('div');
    container.appendChild(range.cloneContents());

    // Get the text content from the temporary container
    var selectedText = container.textContent;

    // Get the parent element of the selected range
    var parentElement = range.commonAncestorContainer.parentElement;

    var spanElements = parentElement.getElementsByTagName("span");

    var fontStyle;
    var fontWeight;
    var fontColour;
    var fontSize;

    // Iterate over the span elements and check if they intersect with the selected range
    for (var i = 0; i < spanElements.length; i++) {
        var spanElement = spanElements[i];

        var spanRange = document.createRange();
        spanRange.selectNode(spanElement);

        // Check if the span range intersects with the selected range
        if (spanRange.intersectsNode(range.startContainer) || spanRange.intersectsNode(range.endContainer)) {
            console.log(spanElement);

            // Access the computed styles and inline styles
            var computedStyles = window.getComputedStyle(spanElement);

            fontStyle = computedStyles.fontStyle;
            fontWeight = computedStyles.fontWeight;
            fontColour = computedStyles.color;
            fontSize = computedStyles.fontSize;
        }
    }

    //if the user has highlighted text
    if (selectedText.length > 0) {
        //if they change the colour wrap highlighted text in styled span
        if (element.id == "colour") {
            span.style.color = element.value;
            span.style.fontStyle = fontStyle;
            span.style.fontWeight = fontWeight;
            span.style.fontSize = fontSize;
            element.style.color = element.value;
            span.innerText = selectedText;
            range.deleteContents();
            range.insertNode(span);
        }

        //if they change the font size wrap highlighted text in styled span
        else if (element.id == "size") {
            span.style.fontSize = element.value;
            span.style.fontStyle = fontStyle;
            span.style.fontWeight = fontWeight;
            span.style.color = fontColour;
            span.innerText = selectedText;
            range.deleteContents();
            range.insertNode(span);
        }
    }


    //if no text is highlighted
    else {
        //if they change the colour
        if (element.id == "colour") {
            element.style.color = element.value;
            textBox.style.color = element.value;
        }

        //if they change the font size
        else if (element.id == "size") {
            textBox.style.fontSize = element.value;
        }
    }
}

//when either italics or bold is selected
function ChangeText(element) {
    console.log("test");
    //highlighted text
    var selection = window.getSelection();

    //content editable div
    const textBox = document.getElementById("text");

    //span element to wrap highlighted text
    const span = document.createElement("span");

    var range = selection.getRangeAt(0);

    // Create a temporary container element to hold the range content
    var container = document.createElement('div');
    container.appendChild(range.cloneContents());

    var selectedText = container.innerText;

    // Get the parent element of the selected range
    var parentElement = range.commonAncestorContainer.parentElement;

    // Get all the span elements within the parent element
    var spanElements = parentElement.getElementsByTagName("span");

    var fontStyle;
    var fontWeight;
    var fontColour;
    var fontSize;

    // Iterate over the span elements and check if they intersect with the selected range
    for (var i = 0; i < spanElements.length; i++) {
        var spanElement = spanElements[i];

        var spanRange = document.createRange();
        spanRange.selectNode(spanElement);

        // Check if the span range intersects with the selected range
        if (spanRange.intersectsNode(range.startContainer) || spanRange.intersectsNode(range.endContainer)) {
            console.log(spanElement);

            // Access the computed styles and inline styles
            var computedStyles = window.getComputedStyle(spanElement);

            fontStyle = computedStyles.fontStyle;
            fontWeight = computedStyles.fontWeight;
            fontColour = computedStyles.color;
            fontSize = computedStyles.fontSize;
        }
    }

    //if text is selected
    if (selectedText.length > 0) {
        //if italics was clicked style the span with italics and wrap highlighted text
        if (element.id == "italic") {
            if (fontStyle != "italic") {
                span.style.fontStyle = "italic";
                span.style.fontWeight = fontWeight;
                span.style.color = fontColour;
                span.style.fontSize = fontSize;
                span.innerText = selectedText;
                range.deleteContents();
                range.insertNode(span);
            }

            else {
                span.style.fontStyle = "normal";
                span.style.fontWeight = fontWeight;
                span.style.color = fontColour;
                span.style.fontSize = fontSize;
                span.innerText = selectedText;
                range.deleteContents();
                range.insertNode(span);
            }
        }

        //if bold was clicked wrap highlighted text in bold span
        else if (element.id == "bold") {
            if (fontWeight != "700") {
                span.style.fontWeight = "bold";
                span.style.fontStyle = fontStyle;
                span.style.color = fontColour;
                span.style.fontSize = fontSize;
                span.innerText = selectedText;
                range.deleteContents();
                range.insertNode(span);
            }

            else {
                span.style.fontWeight = "normal";
                span.style.fontStyle = fontStyle;
                span.style.color = fontColour;
                span.style.fontSize = fontSize;
                range.surroundContents(span);
                span.innerText = selectedText;
                range.deleteContents();
                range.insertNode(span);
            }
        }
    }

    //if no text is highlighted
    else {
        //if italics is clicked
        if (element.id == "italic") {
            //if it wasnt already in italics make it italic
            if (textBox.style.fontStyle != "italic") {
                textBox.style.fontStyle = "italic";
            }

            //if it is in italics return to normal
            else {
                textBox.style.fontStyle = "normal";
            }
        }

        //if bold is clicked
        else if (element.id == "bold") {
            //if it wasnt already bold make it bold
            if (textBox.style.fontWeight != "bold") {
                textBox.style.fontWeight = "bold";
                element.style.backgroundColor = "lightgray";
            }

            //if it is bold make it normal
            else {
                textBox.style.fontWeight = "normal";
                element.style.backgroundColor = "white";
            }
        }
    }
}

function UploadImage() {
    const fileInput = document.getElementById("fileInput");
    fileInput.click();
}

//when the text is added to the post
function AddText() {
    var pattern = /(@@|\*\/|\/\*|--|\/\/|@@\*|\*=@@|<|>|@@\*|\*@@)/g;
    const textBox = document.getElementById("text");
    const post = document.getElementById("post");
    var cloned = textBox.cloneNode(true);
    post.appendChild(cloned);
}

function generateGuid() {
    return 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0,
            v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}