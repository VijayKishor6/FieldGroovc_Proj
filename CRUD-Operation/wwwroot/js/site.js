// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// activateAccount.js
<script nonce="js-vzh2P3Jjc+MLlSRJruF9PA==">
    // Your JavaScript code here
    function activateAccount(email) {
        fetch(`https://localhost:44367/api/FieldGrooveApi/activate?email=${encodeURIComponent(email)}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
        })
            .then(response => {
                if (response.ok) {
                    return response.json();
                } else {
                    throw new Error('Activation failed');
                }
            })
            .then(data => {
                alert(data.message);
                location.reload();
            })
            .catch(error => {
                console.error('Activation error:', error);
                alert('Activation failed. Please try again.');
            });
    }
</script>
