using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidatior : AbstractValidator<Blog>
    {
        public BlogValidatior()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş geçemessiniz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçemessiniz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçemessiniz.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az giriş yapın.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla giriş yapın.");
        }
    }
}
