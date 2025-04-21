document.addEventListener('DOMContentLoaded', function() {
    const roleSelect = document.getElementById('register-role');
    const roleExtraFields = document.getElementById('role-extra-fields');
    const forms = document.querySelectorAll('form');

    // Add modern input animations
    document.querySelectorAll('.input-group input, .input-group select, .input-group textarea').forEach(input => {
        // Add focus animations
        input.addEventListener('focus', () => {
            input.parentElement.classList.add('focused');
        });
        input.addEventListener('blur', () => {
            input.parentElement.classList.remove('focused');
            if (input.value) {
                input.classList.add('has-value');
            } else {
                input.classList.remove('has-value');
            }
        });

        // Initialize has-value state
        if (input.value) {
            input.classList.add('has-value');
        }
    });



    // Dynamic fields for Register with animations
    function renderRoleFields(role) {
        // Fade out current fields
        roleExtraFields.style.opacity = '0';
        
        setTimeout(() => {
            let html = '';
            if (role === 'Doctor') {
                html = `
                    <div class="role-fields doctor-fields">
                        <div class="input-group">
                            <select id="register-sex" required name="Sex">
                                <option value="">Select Sex</option>
                                <option value="male">Male</option>
                                <option value="female">Female</option>
                            </select>
                            <label for="register-sex">Sex</label>
                        </div>
                        <div class="input-group">
                            <input type="date" id="register-dob" required placeholder=" " name="DateOfBirth">
                            <label for="register-dob">Date of Birth</label>
                        </div>
                        <div class="input-group">
                            <input type="text" id="register-specialization" required placeholder=" " name="Specialization">
                            <label for="register-specialization">Specialization</label>
                        </div>
                        <div class="input-group">
                            <textarea id="register-bio" required placeholder=" " name="Bio"></textarea>
                            <label for="register-bio">Bio</label>
                        </div>
                    </div>
                `;
            } else if (role === 'Patient') {
                html = `
                    <div class="role-fields patient-fields">
                        <div class="input-group">
                            <select id="register-sex" required name="Sex">
                                <option value="">Select Sex</option>
                                <option value="male">Male</option>
                                <option value="female">Female</option>
                            </select>
                            <label for="register-sex">Sex</label>
                        </div>
                        <div class="input-group">
                            <input type="date" id="register-dob" required placeholder=" " name="DateOfBirth">
                            <label for="register-dob">Date of Birth</label>
                        </div>
                    </div>
                `;
            }
            
            roleExtraFields.innerHTML = html;
            
            // Animate new fields
            if (html) {
                requestAnimationFrame(() => {
                    roleExtraFields.style.opacity = '1';
                });
            }
            
            // Add input animations to new fields
            roleExtraFields.querySelectorAll('input, textarea, select').forEach(input => {
                input.addEventListener('focus', () => {
                    input.parentElement.classList.add('focused');
                });
                input.addEventListener('blur', () => {
                    input.parentElement.classList.remove('focused');
                    if (input.value) {
                        input.classList.add('has-value');
                    } else {
                        input.classList.remove('has-value');
                    }
                });
            });
        }, 200);
    }

    roleSelect.addEventListener('change', function() {
        renderRoleFields(this.value);
    });

    // Modern form submission with validation and loading state
    forms.forEach(form => {
        form.addEventListener('submit', async function(e) {
            
            
            // Remove previous validation messages
            form.querySelectorAll('.validation-message').forEach(msg => msg.remove());
            
            // Validate all required fields
            let isValid = true;
            form.querySelectorAll('input[required], select[required], textarea[required]').forEach(input => {
                if (!input.value.trim()) {
                    isValid = false;
                    const message = document.createElement('div');
                    message.className = 'validation-message';
                    message.textContent = `Please enter your ${input.previousElementSibling.textContent}`;
                    input.parentElement.appendChild(message);
                    input.classList.add('invalid');
                }
            });

            if (!isValid) return;

            // Show loading state
            const submitBtn = form.querySelector('button[type="submit"]');
            const originalText = submitBtn.textContent;
            submitBtn.disabled = true;
            submitBtn.innerHTML = '<span class="loading-spinner"></span> Processing...';

            // Simulate API call
            try {
                await new Promise(resolve => setTimeout(resolve, 1500));
                submitBtn.innerHTML = '<span class="success-icon">✓</span> Success!';
                form.reset();
                
                setTimeout(() => {
                    submitBtn.disabled = false;
                    submitBtn.textContent = originalText;
                }, 2000);
            } catch (error) {
                submitBtn.innerHTML = 'Error. Try again';
                setTimeout(() => {
                    submitBtn.disabled = false;
                    submitBtn.textContent = originalText;
                }, 2000);
            }
        });
    });

});

