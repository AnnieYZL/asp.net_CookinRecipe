$(document).ready(function () {
    let currentRecipeId = null;
    let selectedListIds = new Set();
    
    document.querySelectorAll('.saveBtn').forEach(btn => {
        btn.addEventListener('click', function () {
            currentRecipeId = this.getAttribute('data-recipe-id');
            selectedListIds.clear();

            // Reset danh sách chọn
            document.querySelectorAll('#listContainer li').forEach(li => li.classList.remove('bg-blue-100'));

            // Hiện modal
            document.getElementById('modalSave').classList.remove('hidden');
        });
    });
    document.getElementById('closeModalSave').addEventListener('click', function () {
        document.getElementById('modalSave').classList.add('hidden');
    });
    
    document.getElementById('newListBtn').addEventListener('click', function () {
        const listContainer = document.getElementById('listContainer');

        // Nếu đang nhập tên thì không cho thêm mới
        if (listContainer.querySelector('input')) return;

        const newItem = document.createElement('li');
        newItem.className = "p-2 bg-gray-100 rounded flex items-center space-x-3 cursor-pointer hover:bg-gray-200";

        const img = document.createElement('img');
        img.src = "/FileUpload/images/list/no-image.png";
        img.className = "w-12 h-12 rounded-lg";
        img.alt = "New List";

        const input = document.createElement('input');
        input.type = "text";
        input.className = "bg-transparent border-b border-gray-500 focus:outline-none font-sans";
        input.placeholder = "Nhập tên danh sách";

        const saveBtn = document.createElement('button');
        saveBtn.textContent = "Tạo";
        saveBtn.className = "ml-2 text-green-600 text-sm font-semibold px-3 py-1 rounded bg-green-100 hover:bg-green-200";

        const cancelBtn = document.createElement('button');
        cancelBtn.textContent = "Hủy";
        cancelBtn.className = "ml-2 text-red-600 text-sm font-semibold px-3 py-1 rounded bg-red-100 hover:bg-red-200";

        saveBtn.addEventListener('click', function () {
            const listName = input.value.trim();
            if (listName === "") return;

            $.ajax({
                type: "POST",
                url: "/Recipe/CreateList",
                data: { listName: listName },
                success: function (response) {
                    if (response.success) {
                        newItem.innerHTML = '';
                        newItem.setAttribute('data-list-id', response.listId);

                        newItem.appendChild(img);

                        const textDiv = document.createElement('div');
                        textDiv.innerHTML = `<span class='font-medium'>${listName}</span><p class='text-sm text-gray-500'>0 công thức</p>`;
                        newItem.appendChild(textDiv);

                        newItem.className = "p-2 bg-gray-100 rounded flex items-center space-x-3 cursor-pointer hover:bg-gray-200";
                    } else {
                        ThongBao("Có lỗi khi tạo mới bộ sưu tập", "warning");
                    }
                },
                error: function () {
                    ThongBao("Đã xảy ra lỗi khi gọi server", "danger");
                }
            });
        });

        cancelBtn.addEventListener('click', function () {
            listContainer.removeChild(newItem);
        });

        newItem.appendChild(img);
        newItem.appendChild(input);
        newItem.appendChild(saveBtn);
        newItem.appendChild(cancelBtn);
        listContainer.appendChild(newItem);
    });
    
    document.getElementById('listContainer').addEventListener('click', function (e) {
        if (!(e.target instanceof Element)) return;

        const li = e.target.closest('li[data-list-id]');
        if (!li) return;

        const listId = li.getAttribute('data-list-id');
        if (selectedListIds.has(listId)) {
            selectedListIds.delete(listId);
            li.classList.remove('bg-blue-100');
        } else {
            selectedListIds.add(listId);
            li.classList.add('bg-blue-100');
        }
    });
    document.getElementById('doneBtn').addEventListener('click', function () {
        if (selectedListIds.size === 0) {
            //ThongBao("Vui lòng chọn ít nhất một bộ sưu tập!", "warning");
            return;
        }

        if (!currentRecipeId) {
            ThongBao("Không xác định được công thức cần lưu!", "danger");
            return;
        }

        const listIdArray = Array.from(selectedListIds);

        $.ajax({
            type: "POST",
            url: "/Recipe/SaveToList",
            traditional: true,
            data: {
                recipeId: currentRecipeId,
                listIds: listIdArray
            },
            success: function (response) {
                if (response.success) {
                    ThongBao("Đã lưu công thức vào danh sách", "success");
                    document.getElementById('modalSave').classList.add('hidden');
                } else {
                    ThongBao("Công thức đã tồn tại trong danh sách rồi", "info");
                }
            },
            error: function () {
                ThongBao("Lỗi khi gọi server", "danger");
            }
        });
    });
    
});
function toggleLikeButton(btn, recipeId) {
    fetch(`/Recipe/ToggleLike/${recipeId}`, {
        method: "POST"
    })
        .then(res => {
            if (!res.ok) throw new Error("Lỗi khi gửi yêu cầu thích");
            return res.json();
        })
        .then(data => {
            if (data.success) {
                if (data.isCancel) {
                    ThongBao("Đã hủy thích công thức", "success");
                    btn.classList.remove("fa-solid", "text-red-600");
                    btn.classList.add("fa-regular", "text-gray-500");
                } else {
                    ThongBao("Đã thích công thức", "success");
                    btn.classList.remove("fa-regular", "text-gray-500");
                    btn.classList.add("fa-solid", "text-red-600");
                }

                document.getElementById("dish-page-num-likes").textContent = data.numLikes;
            } else {
                ThongBao("Không thể thực hiện thao tác", "danger");
            }
        })
        .catch(err => {
            console.error("Toggle like failed:", err);
        });
}
