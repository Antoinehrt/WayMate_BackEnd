describe('My First Test', () => {
  it('Does not do much!', () => {
    cy.visit('https://localhost:7206/swagger/index.html')
    cy.contains('GET').click()
    cy.contains('Try it out').click()
    cy.contains('Execute').click()
    //expect(true).to.equal(true)
  })
})