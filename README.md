# ArasInnovator-toggle-fields-from-relgrid

## Aras Innovator Version 12.0 SP6

## Description
Toggle visibility of form fields when a user selects, inserts, or deletes a row from a relationship grid. In my specific use case we wanted some fields to be visible only if a user had attached a relationship with a certain value for its classification property. This works even when the user is working with many items at once. The delete version of the code contains an additional check that excludes the item being deleted.

## Usage
This code is intended for use from the relationship type as a grid event. 
