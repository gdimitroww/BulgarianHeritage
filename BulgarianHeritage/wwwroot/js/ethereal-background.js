// Ethereal Shadows Animation
document.addEventListener('DOMContentLoaded', function() {
    const hueRotateElement = document.getElementById('hue-rotate');
    const turbulenceElement = document.getElementById('turbulence');
    
    if (hueRotateElement && turbulenceElement) {
        let hueValue = 0;
        let turbulenceX = 0.0003;
        let turbulenceY = 0.003;
        
        function animateEtherealEffect() {
            // Animate hue rotation
            hueValue += 1;
            if (hueValue >= 360) hueValue = 0;
            hueRotateElement.setAttribute('values', hueValue.toString());
            
            // Animate turbulence frequency
            const time = Date.now() * 0.001;
            const newTurbulenceX = 0.0003 + Math.sin(time * 0.5) * 0.0001;
            const newTurbulenceY = 0.003 + Math.cos(time * 0.3) * 0.001;
            
            turbulenceElement.setAttribute('baseFrequency', `${newTurbulenceX},${newTurbulenceY}`);
            
            requestAnimationFrame(animateEtherealEffect);
        }
        
        animateEtherealEffect();
    }
}); 