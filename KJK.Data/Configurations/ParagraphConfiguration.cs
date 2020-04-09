using KJK.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KJK.Data.Configurations
{
	public class ParagraphConfiguration : BaseModelConfiguration<Paragraph>
	{
		public override void Configure(EntityTypeBuilder<Paragraph> builder)
		{
			base.Configure(builder);
			builder.Property(p => p.Choices).HasConversion(
				choicesList => JsonConvert.SerializeObject(choicesList),
				choicesJson => JsonConvert.DeserializeObject<List<Choice>>(choicesJson)
			);
		}
	}
}
