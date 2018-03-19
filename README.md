# Assessment

## Assumptions

- Worker can create cases but not review/approve.
- Worker/Reviewer/Approver can see all cases, but only take action on cases in their appropriate "queue".
    - State is derived from which "queue" the case is in. For example, a case is in the "New" state if it has not been approved.
- State diagram did not explicity demonstrate a "denied" state/queue.

## Getting started

1. Open the `Package Manager Console` window, type in `Update-Database` 
> Database is managed by _EF Migrations_

For convenience sample user and case data is added to the database on application start.