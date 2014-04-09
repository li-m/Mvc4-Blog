function DeleteArticle(id) {
    if (confirm("Are you sure to delete the article?")) {
        window.location = "/Articles/Delete/" + id;
    }
}

function ModifyArticle(id) {
    window.location = "/Articles/Modify/" + id;
}