const image_input = document.querySelector("#input_image");
var uploaded_image = "";
var upload_icon = document.querySelector("#upload_icon");
var display_image = document.querySelector("#display_image");

console.log("Salomlar");

image_input.addEventListener("change", function()
{
    console.log("salom");
    const reader = new FileReader();
    reader.addEventListener("load", () => {
       uploaded_image = reader.result;

       display_image.style.backgroundImage = `url(${uploaded_image})`; 
       display_image.style.backgroundSize = "cover"; 
       display_image.style.backgroundPosition = "center"; 
       display_image.style.backgroundRepeat = "no-repeat"; 
    });
    reader.readAsDataURL(this.files[0]);

    if(display_image.style.backgroundImage =! `url(${uploaded_image})`)
    {
        upload_icon.style.display = "block";
    }
    else
    {
        upload_icon.style.display = "none";

        image_input.addEventListener("mouseover", function handleMouseOver() 
        {
            upload_icon.style.display = "block";
            upload_icon.style.animationDuration = "3s";
        });

        image_input.addEventListener("mouseout", function handleMouseOver() 
        {
            upload_icon.style.display = "none";
            upload_icon.style.animationDuration = "3s";
        });
    }
});