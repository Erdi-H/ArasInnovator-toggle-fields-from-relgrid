/******************************************************************************
Revisions:
    Rev Date        Modified By      Description
*******************************************************************************/
var parentItem = parent.thisItem;
var inn = parentItem.getInnovator();

var parentForm = parent.parent.document.getElementById("instance");
var parentFormWindow = parentForm.contentWindow;

if (parentFormWindow) { // only run when this var is defined
    // get the fields you want to toggle
    var modelYearField = parentFormWindow.getFieldByName("model_year");
    var programPhaseField = parentFormWindow.getFieldByName("program_phase");
    
    var relatedItems = parentItem.getItemsByXPath("//Item[@type='issue_program']");
    var relatedCount = relatedItems.getItemCount();
    var classifications = [];
    for (let i = 0; i < relatedCount; ++i) {
        var currItem = relatedItems.getItemByIndex(i);
        // additional check to ignore item being deleted
        if (currItem.node.id != relationshipID) {
            var classification = currItem.getAttribute("classification");
            
            if (!classification) {
                var itemHTML = currItem.node.innerHTML;
                var classificationMatch = itemHTML.match(/<classification>(.*?)<\/classification>/);
                classification = classificationMatch ? classificationMatch[1] : null;
            }
            classifications.push(classification);
        }
    }
    var hasWiring = classifications.includes("Wiring");
    
    if (hasWiring) {
        modelYearField.style.visibility = 'visible';
        programPhaseField.style.visibility = 'visible';  
    }
    else {
        modelYearField.style.visibility = 'hidden';
        programPhaseField.style.visibility = 'hidden';
    }
}
