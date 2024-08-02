/******************************************************************************
Revisions:
    Rev Date        Modified By      Description
*******************************************************************************/
var parentItem = parent.thisItem;
var inn = parentItem.getInnovator();

var parentForm = parent.parent.document.getElementById("instance");
var parentFormWindow = parentForm.contentWindow;

if (parentFormWindow) { // only run when this var is defined
    var harnessFamilyField = parentFormWindow.getFieldByName("harness_fam");
    var modelYearField = parentFormWindow.getFieldByName("model_year");
    var programPhaseField = parentFormWindow.getFieldByName("program_phase");
    
    var relatedItems = parentItem.getItemsByXPath("//Item[@type='lr_issue_program']");
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
        harnessFamilyField.style.visibility = 'visible';
        modelYearField.style.visibility = 'visible';
        programPhaseField.style.visibility = 'visible';  
    }
    else {
        harnessFamilyField.style.visibility = 'hidden';
        modelYearField.style.visibility = 'hidden';
        programPhaseField.style.visibility = 'hidden';
    }
}
