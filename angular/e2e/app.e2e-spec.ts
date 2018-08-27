import { AccountingV03TemplatePage } from './app.po';

describe('AccountingV03 App', function() {
  let page: AccountingV03TemplatePage;

  beforeEach(() => {
    page = new AccountingV03TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
