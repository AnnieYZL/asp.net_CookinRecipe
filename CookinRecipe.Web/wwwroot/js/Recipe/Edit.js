function previewVideo(input) {
    const file = input.files[0];
    const video = document.getElementById('RecipeVideo');

    if (file) {
        const url = URL.createObjectURL(file);
        video.src = url;
        video.load();
        video.style.display = 'block';
    }
}
let ingredients = @Html.Raw(ingredientsJson);
//let selectedIngredients = new Set();
let selectedIngredients = new Set(@Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(
    RecipeDataService.ListIngredients(Model.RecipeID).Select(x => CommonDataService.GetIngredient(x.IngredientID).IngredientName)
)));
console.log(selectedIngredients);
function searchIngredient() {
    let input = document.getElementById('ingredient-search').value.toLowerCase();
    let suggestions = document.getElementById('ingredient-suggestions');
    suggestions.innerHTML = '';

    if (input === '') {
        suggestions.classList.add('hidden');
        return;
    }

    let filtered = ingredients.filter(ing => ing.IngredientName.toLowerCase().includes(input) && !selectedIngredients.has(ing.IngredientName)
    );

    if (filtered.length === 0) {
        suggestions.classList.add('hidden');
        return;
    }

    filtered.forEach(ing => {
        let div = document.createElement('div');
        div.classList.add('p-2', 'hover:bg-gray-200', 'cursor-pointer');
        div.innerText = ing.IngredientName;
        div.onclick = () => selectIngredient(ing);
        suggestions.appendChild(div);
    });

    suggestions.classList.remove('hidden');
}

function selectIngredient(ingredient) {
    selectedIngredients.add(ingredient.IngredientName);
    document.getElementById('ingredient-search').value = '';
    document.getElementById('ingredient-suggestions').classList.add('hidden');

    let div = document.createElement('div');
    div.classList.add("flex", "gap-2", "mb-2", "items-center");

    let quantityHTML = '';
    if (ingredient.Unit && ingredient.Unit.trim() !== '') {
        quantityHTML = `
                        <input type="text" name="QuantityList" value="0"
                            class="p-2 border border-gray-300 text-gray-900 focus:ring-blue-600 bg-blue-50 focus:border-blue-600 rounded-lg w-1/12"
                            placeholder="Số lượng">
                        <span class="p-2 border rounded bg-gray-100">${ingredient.Unit}</span>
                    `;
    }

    div.innerHTML = `
                    <span class="p-2 border rounded bg-gray-100">${ingredient.IngredientName}</span>
                    <input type="hidden" name="IngredientList" value="${ingredient.IngredientID}" />
                    ${quantityHTML}
                    <input type="text" name="NoteIngre"
                        class="p-2 border border-gray-300 text-gray-900 focus:ring-blue-600 bg-blue-50 focus:border-blue-600 rounded-lg w-1/4"
                        placeholder="Ghi chú">
                    <button type="button" onclick="removeIngredient('${ingredient.IngredientName}', this)" class="text-red-500 text-lg font-bold">×</button>
                `;

    document.getElementById('selected-ingredients').appendChild(div);
}


function removeIngredient(ingredientName, button) {
    selectedIngredients.delete(ingredientName);
    button.parentElement.remove();
}
function addStep() {
    let stepsList = document.getElementById('steps');
    let childCount = stepsList.childElementCount;
    let step = document.createElement('textarea');
    step.type = 'text';
    step.name = "StepList";
    step.rows = 4;
    step.classList = 'w-full font-sans p-2 bg-blue-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-600 focus:border-blue-600 mb-2';
    step.placeholder = 'Nhập bước ' + String(childCount + 1);
    document.getElementById('steps').appendChild(step);
}

function addNote() {
    let notesList = document.getElementById('notes');
    let childCount = notesList.childElementCount;
    let note = document.createElement('textarea');
    note.type = 'text';
    note.name = "NoteList";
    note.rows = 4;
    note.classList = 'w-full font-sans p-2 bg-blue-50 border border-gray-300 text-gray-900 rounded-lg focus:ring-blue-600 focus:border-blue-600 mb-2';
    note.placeholder = 'Nhập ghi chú ' + String(childCount + 1);
    document.getElementById('notes').appendChild(note);
}

// Course
const availableTags = @Html.Raw(coursesJson);
const tagContainer = document.getElementById("tagContainer");
const tagWrapper = document.getElementById("tagWrapper");
const tagInput = document.getElementById("tagInput");
const suggestions = document.getElementById("suggestions");
let selectedTags = new Set(@Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(
    RecipeDataService.GetCoursesOf(Model.RecipeID).Select(x => CommonDataService.GetCourse(x.CourseID).CourseName)
)));
console.log(selectedTags);

function showSuggestions() {
    let input = tagInput.value.toLowerCase();
    suggestions.innerHTML = "";

    let filteredTags = availableTags.filter(tag => tag.CourseName.toLowerCase().includes(input) && !selectedTags.has(tag.CourseName));
    if (filteredTags.length === 0) {
        suggestions.classList.add("hidden");
        return;
    }

    filteredTags.forEach(tag => {
        let li = document.createElement("li");
        li.textContent = tag.CourseName;
        li.classList.add("p-2", "cursor-pointer", "hover:bg-gray-200", "font-sans");
        li.onclick = () => addTag(tag);
        suggestions.appendChild(li);
    });
    suggestions.classList.remove("hidden");
}

function removeTag(buttonElement) {
    const span = buttonElement.parentElement;
    const tagName = span.firstChild.textContent.trim(); // Lấy tên khoá học (CourseName)

    // Xoá thẻ tag
    span.remove();

    // Xoá khỏi tập selectedTags
    selectedTags.delete(tagName);

    // Ẩn container nếu không còn tag nào
    if (tagContainer.children.length === 0) {
        tagWrapper.classList.add("hidden");
    }
}


function addTag(tag) {
    if (selectedTags.has(tag.CourseName)) return;
    selectedTags.add(tag.CourseName);
    let span = document.createElement("span");
    span.textContent = tag.CourseName;
    span.classList.add("bg-gray-200", "px-3", "py-1", "rounded", "flex", "items-center", "gap-1");

    let removeBtn = document.createElement("button");
    removeBtn.textContent = "×";
    removeBtn.classList.add("ml-2", "text-red-500", "cursor-pointer");
    removeBtn.setAttribute("onclick", "removeTag(this)");


    span.appendChild(removeBtn);
    tagContainer.appendChild(span);

    tagInput.value = "";
    suggestions.classList.add("hidden");

    let hiddenInput = document.createElement("input");
    hiddenInput.type = "hidden";
    hiddenInput.name = "CourseList";
    hiddenInput.value = tag.CourseID;
    span.appendChild(hiddenInput);
}

function handleKeyPress(event) {
    if (event.key === "Enter" && tagInput.value.trim() !== "") {
        addTag(tagInput.value.trim());
    }
}