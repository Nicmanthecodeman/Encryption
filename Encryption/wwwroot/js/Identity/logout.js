function AttemptLogout() {
    swal.fire({
        "title": "Are you sure?",
        "text": "This will clear all session data.",
        "icon": "question",
        "showCancelButton": true,
        "reverseButtons": true,
        "confirmButtonText": "Logout",
        "cancelButtonColor": '#d33',
    }).then((result) => {
        if (result.isConfirmed) {
            $('#logoutForm').submit();
        }
    });
}