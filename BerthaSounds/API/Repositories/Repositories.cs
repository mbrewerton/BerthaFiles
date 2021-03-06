﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
	public partial interface IUserRepository : IRepository<ApplicationUser> { }
	public partial class UserRepository : GenericRepository<ApplicationUser>
	{
		public UserRepository(IObjectContext objectContext) : base(objectContext) { }
	}

    public partial interface ISoundRepository : IRepository<Sound> { }
    public partial class SoundRepository : GenericRepository<Sound>
    {
        public SoundRepository(IObjectContext objectContext) : base(objectContext) { }
    }

    public partial interface ICouponRepository : IRepository<Coupon> { }
    public partial class CouponRepository : GenericRepository<Coupon>
    {
        public CouponRepository(IObjectContext objectContext) : base(objectContext) { }
    }

    public partial interface ICouponTypeRepository : IRepository<CouponType> { }
    public partial class CouponTypeRepository : GenericRepository<CouponType>
    {
        public CouponTypeRepository(IObjectContext objectContext) : base(objectContext) { }
    }

	public partial interface IUserProfileRepository : IRepository<UserProfile> { }
	public partial class UserProfileRepository : GenericRepository<UserProfile>
	{
		public UserProfileRepository(IObjectContext objectContext) : base(objectContext) { }
	}
    
    public partial interface ICategoryRepository : IRepository<Category> { }
    public partial class CategoryRepository : GenericRepository<Category>
    {
		public CategoryRepository(IObjectContext objectContext) : base(objectContext) { }
    }
    
    public partial interface ITagRepository : IRepository<Tag> { }
    public partial class TagRepository : GenericRepository<Tag>
    {
		public TagRepository(IObjectContext objectContext) : base(objectContext) { }
    }
}
