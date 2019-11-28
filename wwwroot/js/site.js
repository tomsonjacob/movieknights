let isOpen = false;

function ToggleLogin(){

    if(!isOpen) {//open panel
        $('#loginPanel').animate({
            top: 0
        }, 220, 'swing');
        isOpen = true;
    }
    else { //close panel
        $('#loginPanel').animate({
            top: -100
        }, 220, 'swing');

        isOpen = false;
    }
}//Togglelogin()