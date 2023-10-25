## Vending machine design 

We will be designing a vending machine in this project.

## How Vending machine works

User will insert coin into the machine, select an item to buy and the machine dispenses off the item.

Inputs -> insert coin, select item
Output -> Get item

## States of the vending machine

1. Idle state : The machine starts off in this state and is not doing any action in this state.
2. Processing State : The user inserts coin and selects item and machine starts processing.
3. Sold State : The machine dispenses off the item to the user.
4. Sold out state : The machine does not enough item to sell.

## Transition between states

1. Machine starts off in sold out state
2. Once machine is loaded with certain default no of items it goes to idle state.
3. When user selects item, machine goes to processing state from idle state.
4. When user inserts coin, machine goes from processing state to sold state.
4. Machine dispenses off the item and goes to idle state if it has enough items, else sold out state and waits to be refilled.
