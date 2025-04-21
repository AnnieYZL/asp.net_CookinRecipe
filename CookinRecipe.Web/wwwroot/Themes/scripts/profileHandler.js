function getStoredProfile(){
    let profileUrl = String(window.localStorage.getItem('PROFILE_URL'));
    let fullName = String(window.localStorage.getItem('NAME'));
    let caption = String(window.localStorage.getItem('CAPTION'));
    let createdAt = String(window.localStorage.getItem('CREATED_AT'));
    let gender = String(window.localStorage.getItem('GENDER'));
    let currentLocation = String(window.localStorage.getItem('LOCATION'));
    let email = String(window.localStorage.getItem('EMAIL'));
    return [profileUrl, fullName, caption, createdAt, gender, currentLocation, email]
}

function removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}

function populatePostCards(data){
    let postSection = document.getElementById('self-posts');
    removeAllChildNodes(postSection);

    for(let i = 0; i < data.length; i++){
        let dish = data[i];

        // Card div
        let postCard = document.createElement('div');
        postCard.className = 'rounded overflow-hidden shadow-lg transition duration-500 ease-in-out transform hover:-translate-y-1 hover:scale-105 ...';

        // Image
        let dishImage = document.createElement('img');
        dishImage.id = dish["DISH_ID"];
        dishImage.className = 'w-full h-64 object-cover cursor-pointer';
        dishImage.src = dish["DISH_IMG_URL"];
        dishImage.alt = dish["DISH_NAME"];
        dishImage.onclick = (element) => {
            window.localStorage.setItem("WATCH_DISH_ID", element.target.id);
            window.location.href = "dish.html";
        }

        // Text div
        let textDiv = document.createElement('div');
        textDiv.className = 'px-6 py-4';
        let titleText = document.createElement('div');
        titleText.className = 'font-medium text-xl mb-2 overflow-ellipsis overflow-hidden whitespace-nowrap cursor-pointer';
        titleText.textContent = dish["DISH_NAME"];
        titleText.id = dish["DISH_ID"];
        titleText.onclick = (element) => {
            window.localStorage.setItem("WATCH_DISH_ID", element.target.id);
            window.location.href = "dish.html";
        }

        textDiv.appendChild(titleText);
        let captionText = document.createElement('p');
        captionText.className = 'font-regular text-gray-600 text-base leading-normal h-12 overflow-ellipsis overflow-hidden w-full';
        let ings = dish["DISH_INGREDIENTS"];
        ings = ings.replaceAll('$', ', ').trim(', ');
        captionText.textContent = ings;
        textDiv.appendChild(captionText);

        // Tag div
        let tagDiv = document.createElement('div');
        tagDiv.className = 'px-6 pb-2 flex flex-row';
        let tagSpan = document.createElement('span');
        tagSpan.className = 'inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2';
        tagSpan.textContent = dish["CUISINE_TYPE"];
        tagDiv.appendChild(tagSpan);

        // Edit button
        let editButton = document.createElementNS("http://www.w3.org/2000/svg", "svg");
        editButton.id = dish["DISH_ID"];
        let editPath = document.createElementNS("http://www.w3.org/2000/svg", "path");
        editPath.setAttribute("d", "M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z");
        editPath.setAttribute("id", dish["DISH_ID"]);
        editButton.setAttribute("class", "w-6 h-6 fill-current text-blue-600 ml-auto cursor-pointer");
        editButton.setAttribute("id", dish["DISH_ID"]);
        editButton.onclick = (element) => {
            toggleEditPostModal(element.target.id, true);
        }
        editButton.appendChild(editPath);
        editButton.setAttribute("viewBox", "0 0 20 20");
        editButton.setAttribute("xmlns", "http://www.w3.org/2000/svg");
        tagDiv.appendChild(editButton);

        postCard.appendChild(dishImage);
        postCard.appendChild(textDiv);
        postCard.appendChild(tagDiv);

        postSection.appendChild(postCard);
    }

}

// function populatePosts(){
//     let ownerEmail = window.localStorage.getItem('EMAIL');
//     if(ownerEmail === null || ownerEmail === undefined){
//         document.getElementById('self-posts').style.display = 'none';
//     }
//     else {
//         document.getElementById('self-no-posts').style.display = 'none';
//         $.ajax({
//             type: 'POST',
//             url: 'http://localhost:8000/getSelfPostedDishes',
//             data: JSON.stringify({'owner_email': ownerEmail}),
//             success: function(res) {
//                 data = JSON.parse(res);
//                 if(data["data"].length === 0){
//                     document.getElementById('self-no-posts').style.display = 'block';
//                 }
//                 else{
//                     populatePostCards(data["data"]);
//                 }
//             },
//             error: function(error){
//                 console.log('Error');
//                 console.log(JSON.stringify(error));
//             }
//         })
//     }
// }

function populateProfileData() {
    const [profileUrl, fullName, caption, createdAt, gender, currentLocation, email] = getStoredProfile(); 
    if(profileUrl!=='null'){
        document.getElementById('self-profile-image').src = profileUrl;
        document.getElementById('self-edit-profile').src = profileUrl;
    }
    if(fullName!=='null'){
        document.getElementById('self-name').innerHTML = fullName;
        document.getElementById('self-about-name').innerHTML = fullName;
        document.getElementById('self-edit-name').value = fullName;
    }
    if(caption!=='null'){
        document.getElementById('self-caption').innerHTML = caption;
        document.getElementById('self-edit-caption').value = caption;
    }
    if(createdAt!=='null'){
        document.getElementById('self-created-at').innerHTML = createdAt;
    }
    if(gender!=='null'){
        document.getElementById('self-about-gender').innerHTML = gender;
        if(gender==="Male"){
            document.getElementById('self-edit-male').checked = true;
        }
        else {
            document.getElementById('self-edit-female').checked = true;
        }
    }
    if(currentLocation!=='null'){
        document.getElementById('self-about-location').innerHTML = currentLocation;
        document.getElementById('self-edit-location').value = currentLocation;
    }
    if(email!=='null'){
        let userBadge = getBorderBadgeForUser(email);
        document.getElementById('self-badge').style.background = userBadge["color"];
        document.getElementById('self-badge').textContent = userBadge["text"];
        document.getElementById('self-about-email').innerHTML = email;
        document.getElementById('self-about-email').href = 'mailto:' + email;
        document.getElementById('self-edit-email').value = email;
    }
    // populatePosts();
}

function locallyStoreUser(res) {
    if('email' in res){
        window.localStorage.setItem('EMAIL', res.email);
    }
    if('name' in res){
        window.localStorage.setItem('NAME', res.name);
    }
    if('gender' in res){
        window.localStorage.setItem('GENDER', res.gender);
    }
    if('profile' in res){
        window.localStorage.setItem('PROFILE_URL', res.profile);
    }
    if('location' in res){
        window.localStorage.setItem('LOCATION', res.location);
    }
    if('caption' in res){
        window.localStorage.setItem('CAPTION', res.caption);
    }
    if('created_at' in res){
        window.localStorage.setItem('CREATED_AT', res.created_at);
    }
}

function editProfileChange(){
    var preview = document.getElementById('self-edit-profile');
    var file = document.getElementById('self-upload-profile').files[0];
    var reader  = new FileReader();
 
    reader.addEventListener("load", function () {
        // convert image file to base64 string
        preview.src = reader.result;
      }, false);
    if (file) {
      reader.readAsDataURL(file);
    }
}

function collectChangedProfileData() {
    const [storedProfileUrl,
        storedFullName,
        storedCaption,
        storedCreatedAt,
        storedGender,
        storedCurrentLocation,
        storedEmail] = getStoredProfile();
    let profileImage = document.getElementById('self-edit-profile');
    let fullName = document.getElementById('self-edit-name');
    let email = document.getElementById('self-edit-email');
    let currentLocation = document.getElementById('self-edit-location');
    let genderMale = document.getElementById('self-edit-male');
    let genderFemale = document.getElementById('self-edit-female');
    let caption = document.getElementById('self-edit-caption');
    let defaultImageUrl = new URL('../assets/images/default-profile.jpeg', window.location.protocol + '//' + window.location.host + window.location.pathname).href;

    let updatedData = {};
    if(profileImage.src !== defaultImageUrl && profileImage.src !== storedProfileUrl){
        updatedData["profile"] = profileImage.src;
    }
    if(fullName.value.trim()!==storedFullName){
        const fName = fullName.value.trim();
        if(fName.length < 6){
            alert('Full Name should be of atleast 6 characters.');
            return null;
        }
        updatedData["name"] = fName;
    }
    if(email.value.trim()!==storedEmail){
        const eText = email.value.trim();
        const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if(eText === null || eText.length === 0 || !re.test(eText)){
            alert('Enter valid email.');
            return null;
        }
        updatedData["oldEmail"] = storedEmail;
        updatedData["newEmail"] = eText;
    }
    else {
        updatedData["newEmail"] = email.value.trim();
    }
    if(currentLocation.value.trim()!==storedCurrentLocation && currentLocation.value.trim()!==''){
        updatedData["location"] = currentLocation.value.trim();
    }
    if(genderMale.checked && storedGender!=="Male"){
        updatedData["gender"] = "Male";
    }
    else if(genderFemale.checked && storedGender!=="Female"){
        updatedData["gender"] = "Female";
    }
    if(caption.value.trim()!==storedCaption){
        if(caption.value.trim()!=="" || (caption.value.trim()==="" && storedCaption!=="null")){
            updatedData["caption"] = caption.value.trim();
        }
    }
    toggleModal();
    return updatedData;
}

function onSavingEditForm(){
    let changedData = collectChangedProfileData();
    if(changedData === null || Object.keys(changedData).length === 0){
        return;
    }
    if("newEmail" in changedData && Object.keys(changedData).length == 1){
        return;
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:8000/updateUser',
        data: JSON.stringify(changedData),
        success: function(res) {
            var expires = (new Date(Date.now()+ 86400*1000)).toUTCString();
            document.cookie = "FOOD_LOVERS_LOGIN=" + res["email"] + "; expires=" + expires + ";path=/;";
            locallyStoreUser(res);
            populateProfileData();
        },
        error: function(error){
            console.log('Error');
            console.log(JSON.stringify(error));
        }
    })
}

function handleLogout(){
    $.removeCookie('FOOD_LOVERS_LOGIN', { path: '/' });
    window.location.href = 'home.html';
    storageKeys = ['PROFILE_URL', 'NAME', 'EMAIL', 'LOCATION', 'CREATED_AT', 'CAPTION', 'GENDER']
    for(let i=0; i<storageKeys.length; i++){
        if(storageKeys[i] in window.localStorage){
            window.localStorage.removeItem(storageKeys[i]);
        }
    }
}

// Edit Profile Modal Start
var openmodal = document.querySelectorAll('.modal-open')
for (var i = 0; i < openmodal.length; i++) {
    openmodal[i].addEventListener('click', function(event){
    event.preventDefault();
    populateProfileData();
    toggleModal();
    })
}

const overlay = document.querySelector('.modal-overlay')
overlay.addEventListener('click', toggleModal)

var closemodal = document.querySelectorAll('.modal-close')
for (var i = 0; i < closemodal.length; i++) {
    closemodal[i].addEventListener('click', toggleModal)
}

document.onkeydown = function(evt) {
    evt = evt || window.event
    var isEscape = false
    if ("key" in evt) {
    isEscape = (evt.key === "Escape" || evt.key === "Esc")
    } else {
    isEscape = (evt.keyCode === 27)
    }
    if (isEscape && document.body.classList.contains('modal-active')) {
    toggleModal()
    }
};


function toggleModal () {
    const body = document.querySelector('body')
    const modal = document.querySelector('.modal')
    modal.classList.toggle('opacity-0')
    modal.classList.toggle('pointer-events-none')
    body.classList.toggle('modal-active')
}
// Edit Profile Modal End




populateProfileData();

