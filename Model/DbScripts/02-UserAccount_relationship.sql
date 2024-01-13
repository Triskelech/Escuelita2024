ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Account_AccountId]
GO