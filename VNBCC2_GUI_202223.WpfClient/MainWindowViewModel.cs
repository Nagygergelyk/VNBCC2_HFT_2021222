using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VNBCC2_HFT_2021222.Models;

namespace VNBCC2_GUI_202223.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Brand> Brands { get; set; }

        public RestCollection<Guitar> Guitars { get; set; }

        public RestCollection<Shape> Shapes { get; set; }


        public ICommand CreateBrandCommand { get; set; }

        public ICommand DeleteBrandCommand { get; set; }

        public ICommand UpdateBrandCommand { get; set; }

        public ICommand CreateGuitarCommand { get; set; }

        public ICommand DeleteGuitarCommand { get; set; }

        public ICommand UpdateGuitarCommand { get; set; }

        public ICommand CreateShapeCommand { get; set; }

        public ICommand DeleteShapeCommand { get; set; }

        public ICommand UpdateShapeCommand { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name = value.Name,
                        BrandId = value.BrandId
                    };
                }
                OnPropertyChanged();
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Guitar selectedGuitar;

        public Guitar SelectedGuitar
        {
            get { return selectedGuitar; }
            set
            {
                if (value != null)
                {
                    selectedGuitar = new Guitar()
                    {
                        BasePrice = value.BasePrice,
                        Id = value.Id,
                        Year = 2000
                        
                    };
                }
                OnPropertyChanged();
                (DeleteGuitarCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Shape selectedShape;

        public Shape SelectedShape
        {
            get { return selectedShape; }
            set
            {
                if (value != null)
                {
                    selectedShape = new Shape()
                    {
                        Name = value.Name,
                        ShapeId = value.ShapeId
                    };
                }
                OnPropertyChanged();
                (DeleteShapeCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
         
        public int IdCounter(int id)
        {
            
            return id++;
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Brands = new RestCollection<Brand>("http://localhost:48507/", "brand", "hub");
                Guitars = new RestCollection<Guitar>("http://localhost:48507/", "guitar", "hub");
                Shapes = new RestCollection<Shape>("http://localhost:48507/", "shape", "hub");

            //Brand
            CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name
                    }); 
                }
                );
            }
            
            UpdateBrandCommand = new RelayCommand(() =>
            {
                try
                {
                    Brands.Update(SelectedBrand);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
            );

            DeleteBrandCommand = new RelayCommand(() =>
            {
                Brands.Delete(SelectedBrand.BrandId);

            },
            () =>
            {
                return SelectedBrand != null;
            }
            );
            SelectedBrand = new Brand();
            //Guitar
            int iDent = Guitars.Count();
            CreateGuitarCommand = new RelayCommand(() =>
            {
                Guitars.Add(new Guitar()
                {
                    BasePrice = SelectedGuitar.BasePrice,
                    Id = IdCounter(iDent),
                    ShapeId = 1,
                    BrandId = 1,
                    Year = 1999
                    
                });
             }
             );

            UpdateGuitarCommand = new RelayCommand(() =>
            {
            try
            {
                Guitars.Update(SelectedGuitar);
            }
            catch (ArgumentException ex)
            {
                ErrorMessage = ex.Message;
            }
            });

            DeleteGuitarCommand = new RelayCommand(() =>
            {
                Guitars.Delete(SelectedGuitar.Id);
            }, () =>
            {
                return SelectedGuitar != null;
            }
            );
            SelectedGuitar = new Guitar();
            //Shape
            CreateShapeCommand = new RelayCommand(() =>
            {
                Shapes.Add(new Shape()
                {
                    Name = SelectedShape.Name
                });
            });

            UpdateShapeCommand = new RelayCommand(() =>
            {
                try
                {
                    Shapes.Update(SelectedShape);
                }
                catch (ArgumentException ex)
                {
                    ErrorMessage = ex.Message;
                }
            });


            DeleteShapeCommand = new RelayCommand(() =>
            {
                Shapes.Delete(SelectedShape.ShapeId);

            },
            () =>
            {
                return SelectedShape != null;
            }
            );
            SelectedShape = new Shape();
            
        }
        
    }
}

