window.spinWheel = function (finalDegrees, dotNetHelper) {
    const wheel = document.getElementById('fortuneWheel');
    if (!wheel) {
        console.error('Element #fortuneWheel not found');
        return;
    }

    const totalSpins = 10; // 10 full spins
    const totalDegrees = 360 * totalSpins + finalDegrees;
    const duration = 5000; // total duration in ms (5 seconds for a slower rotation)
    const startTime = performance.now();

    function animate(time) {
        const elapsed = time - startTime;
        const progress = Math.min(elapsed / duration, 1);

        // Ease-in-out function for smooth acceleration and deceleration
        const easedProgress = easeInOutCubic(progress);

        const currentDegrees = totalDegrees * easedProgress;
        wheel.style.transform = `rotate(${currentDegrees}deg)`;

        if (progress < 1) {
            requestAnimationFrame(animate);
        } else {
            // Notify Blazor that the spin has completed
            dotNetHelper.invokeMethodAsync('OnSpinCompleted').catch(err => console.error(err));
        }
    }

    requestAnimationFrame(animate);
};

function easeInOutCubic(t) {
    return t < 0.5 ? 4 * t * t * t : 1 - Math.pow(-2 * t + 2, 3) / 2;
}

window.resetWheel = function () {
    const wheel = document.getElementById('fortuneWheel');
    if (wheel) {
        wheel.style.transition = 'transform 0s';
        wheel.style.transform = 'rotate(0deg)';
    } else {
        console.error('Element #fortuneWheel not found');
    }
};
