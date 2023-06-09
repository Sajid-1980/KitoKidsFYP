﻿using KitoKidsFYP.Areas.Admin.Models;
using KitoKidsFYP.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KitoKidsFYP.Data;

public class KitoKidsFYPContext : IdentityDbContext<ApplicationUser>
{
    public KitoKidsFYPContext(DbContextOptions<KitoKidsFYPContext> options)
        : base(options)
    {
    }


    //DbSet

   
    public DbSet<ClusterFruitLevel1>  ClusterFruitLevel1s { get; set; } 
    public DbSet<ToysLevel1>  ToysLevel1s { get; set; }
    public DbSet<ToysLevel2>  ToysLevel2s { get; set; }
    public DbSet<AlphaLevel1> AlphaLevel1s { get; set; } 
    public DbSet<AlphabetLevel1>   AlphabetLevel1s { get; set; } 


    //Level 2
    public DbSet<ClusterFruitLevel2>   ClusterFruitLevel2s { get; set; } 
    public DbSet<ClusterFruitLevel3>   ClusterFruitsLevel3s { get; set; }




    // Level 3
    public DbSet<Level3Cluster>   Level3Clusters { get; set; }
    public DbSet<NumbersSystemLevel1> Levelone { get; set; }






}
