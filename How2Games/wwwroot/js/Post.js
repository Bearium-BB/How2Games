function CreateQuestion() {
    var formData = new FormData();
    var question = document.getElementById("post").innerHTML;
    var gameId = document.getElementById("gameId").value;
    var title = document.getElementById("title").value;

    formData.append("questionText", question);
    formData.append("gameId", gameId);
    formData.append("title", title);

    fetch('/Posts/SubmitQuestion', {
        method: "POST",
        body: formData
    })
    var gameName = getParameterByName("gameName");
    window.location.href = "https://localhost:7180/Game/GamePage?GameName=" + gameName;
}

function getParameterByName(name) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)');
    var results = regex.exec(window.location.href);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

document.getElementById('fileInput').addEventListener('change', function () {
    console.log("File Selected");
    var fileInput = this;
    var file = fileInput.files[0];

    if (file) {
        var formData = new FormData();
        formData.append('file', file);
        var fileName = generateGuid() + ".jpg";

        formData.append('fileName', fileName);

        fetch('/Posts/UploadFile', {
            method: 'POST',
            body: formData
        })
            .then(function (response) {
                if (response.ok) {
                    return response.json();
                } else {
                    throw new Error('File upload failed.');
                }
            })
            .then(function (data) {
                if (data.success) {
                    console.log('File uploaded successfully.');

                    var imgElement = document.createElement('img');
                    imgElement.src = data.filePath;

                    var imageContainer = document.getElementById('post');
                    imageContainer.appendChild(imgElement);
                } else {
                    console.error(data.error);
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
    const textBox = document.getElementById("textBox");

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
    //highlighted text
    var selection = window.getSelection();

    //content editable div
    const textBox = document.getElementById("textBox");

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
    const textBox = document.getElementById("textBox");
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

function Answer() {
    const textEditor = document.getElementById("answerText");

    if (textEditor.style.display == "none") {
        textEditor.style.display = "block";
    }

    else {
        textEditor.style.display = "none";
    }

    textEditor.scrollIntoView({
        behavior: "smooth", // Use smooth scrolling animation
        block: "start", // Scroll to the top of the div
    });
}

function AddAnswer() {
    var formData = new FormData();
    var answer = document.getElementById("text2").innerHTML;
    var questionId = document.getElementById("questionId").value;

    formData.append("answerText", answer);
    formData.append("questionId", questionId);

    const textEditor = document.getElementById("answerText");
    textEditor.style.display = "none";

    fetch('/Posts/CreateAnswer', {
        method: "POST",
        body: formData
    })
}

function UpVote(answerId) {
    var formData = new FormData();

    formData.append("answerId", answerId);

    fetch('/Posts/CreateUpVote', {
        method: "POST",
        body: formData
    })
}

function DownVote(answerId) {
    var formData = new FormData();

    formData.append("answerId", answerId);

    fetch('/Posts/CreateDownVote', {
        method: "POST",
        body: formData
    })
}

function Comment(answerId) {
    const textEditor = document.getElementById("commentText");

    if (textEditor.style.display == "none") {
        textEditor.style.display = "block";
    }

    else {
        textEditor.style.display = "none";
    }

    const answerInput = document.getElementById("answerId");
    answerInput.value = answerId;

    textEditor.scrollIntoView({
        behavior: "smooth", // Use smooth scrolling animation
        block: "start", // Scroll to the top of the div
    });
}

function AddComment() {
    var formData = new FormData();
    var comment = document.getElementById("text3").innerHTML;
    var answerId = document.getElementById("answerId").value;

    formData.append("commentText", comment);
    formData.append("answerId", answerId);

    const textEditor = document.getElementById("commentText");
    textEditor.style.display = "none";

    fetch('/Posts/CreateComment', {
        method: "POST",
        body: formData
    })
}

function DisplayComments(i) {
    const comments = document.getElementById("comments-" + i);

    if (comments.style.display == "none") {
        comments.style.display = "block";
    }

    else {
        comments.style.display = "none";
    }
}