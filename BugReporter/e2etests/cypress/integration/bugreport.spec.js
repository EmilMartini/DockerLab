it('open page', () => {
    cy.visit("http://localhost:1234")
})

it('create bug report', () => {
    cy.wait(1000);
    cy.get('#box').type('Test nummer 2');
    cy.wait(1000);
})
//
it('press report button', () => {
    cy.get('#reportbutton').click()
    //cy.visit('http://bugreporter.frontend/Report')
})
//

it('press viewpage button', () => {
    cy.get('#viewpage').click()
})

it('press completepage button', () => {
    cy.get('#completepage').click()
})
it('press reportpage button', () => {
    cy.get('#reportpage').click()
})