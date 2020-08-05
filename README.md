# SchoolMgmt_Final
### User Registration
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/User%20Registration.PNG
### User Login success
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/UserLogin_success.PNG
### User Login Failure
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/UserInvalid_login.PNG

### Admin rights to add delete update edit  courses and sections
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_Create_Courses.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_Create_Sections.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_Create_Sections.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_Delete_Sections.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_PartialUpdate_Courses.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_PartialUpdate_Sections.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_Update_Courses.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_Update_Sections.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_View_Courses.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Admin_allowed_view_Sections.PNG

### Other users are not allowed to Add, delete, edit, update courses and sections
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Forbidden_Add_course.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Forbidden_Delete_course.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Forbidden_Delete_section.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Forbidden_Edit_course.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Forbidden_PartialEdit_course.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Forbidden_PartialUpdate_section.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_Notallowed_Add_Sections.PNG

### Other users allowed view courses and sections
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_allowed_View_Courses.PNG
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/Student_allowed_View_Sections.PNG

### User Login with Swagger
https://github.com/cfazle/SchoolMgmtAPI_Final/blob/master/Images/UserLogin_withSwagger.PNG

### Swagger Files
{
  "openapi": "3.0.1",
  "info": {
    "title": "Code Maze API",
    "description": "SchoolMgmtSystem API by CodeMaze",
    "termsOfService": "https://example.com/terms",
    "contact": {
      "name": "John Doe",
      "url": "https://twitter.com/johndoe",
      "email": "JDoe@mail.com"
    },
    "license": {
      "name": "SchoolMgmtSystem API LICX",
      "url": "https://example.com/license"
    },
    "version": "v1"
  },
  "paths": {
    "/api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments/{enrollmentId}/assignments": {
      "get": {
        "tags": [
          "Assignments"
        ],
        "parameters": [
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "PageNumber",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "PageSize",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "OrderBy",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Fields",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Assignments"
        ],
        "parameters": [
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForCreationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments/{enrollmentId}/assignments/{id}": {
      "get": {
        "tags": [
          "Assignments"
        ],
        "parameters": [
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Assignments"
        ],
        "parameters": [
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Assignments"
        ],
        "parameters": [
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/AssignmentForUpdateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Assignments"
        ],
        "parameters": [
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/authentication": {
      "post": {
        "tags": [
          "Authentication"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForRegistrationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/authentication/login": {
      "post": {
        "tags": [
          "Authentication"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/AutUserForAuthenticationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses": {
      "get": {
        "tags": [
          "Courses"
        ],
        "parameters": [
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "PageNumber",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "PageSize",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "OrderBy",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Fields",
            "in": "query",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Courses"
        ],
        "parameters": [
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/CourseForCreationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{id}": {
      "get": {
        "tags": [
          "Courses"
        ],
        "parameters": [
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Courses"
        ],
        "parameters": [
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Courses"
        ],
        "parameters": [
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/CourseForUpdateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Courses"
        ],
        "parameters": [
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments": {
      "get": {
        "tags": [
          "Enrollments"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "PageNumber",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "PageSize",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "OrderBy",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Fields",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Enrollments"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForCreationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments/{id}": {
      "get": {
        "tags": [
          "Enrollments"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Enrollments"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Enrollments"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/EnrollmentForUpdateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Enrollments"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations": {
      "get": {
        "tags": [
          "Organization"
        ],
        "summary": "Gets the list of all organizations",
        "operationId": "GetOrganizations",
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Organization"
        ],
        "summary": "Creates a newly created company",
        "operationId": "CreateOrganization",
        "requestBody": {
          "description": "",
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForCreationDto"
              }
            }
          }
        },
        "responses": {
          "201": {
            "description": "Returns the newly created item"
          },
          "400": {
            "description": "If the item is null",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.hateoas+json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.apiroot+json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.hateoas+xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.apiroot+xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          },
          "422": {
            "description": "If the model is invalid",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.hateoas+json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.apiroot+json": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.hateoas+xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              },
              "application/vnd.codemaze.apiroot+xml": {
                "schema": {
                  "$ref": "#/components/schemas/ProblemDetails"
                }
              }
            }
          }
        }
      },
      "options": {
        "tags": [
          "Organization"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{id}": {
      "get": {
        "tags": [
          "Organization"
        ],
        "operationId": "OrganizationById",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Organization"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Organization"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/OrganizationForUpdateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Organization"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/collection/({ids})": {
      "get": {
        "tags": [
          "Organization"
        ],
        "operationId": "OrganizationCollection",
        "parameters": [
          {
            "name": "ids",
            "in": "query",
            "schema": {
              "type": "array",
              "items": {
                "type": "string",
                "format": "uuid"
              }
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/collection": {
      "post": {
        "tags": [
          "Organization"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/OrganizationForCreationDto"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api": {
      "get": {
        "tags": [
          "Root"
        ],
        "operationId": "GetRoot",
        "parameters": [
          {
            "name": "Accept",
            "in": "header",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections": {
      "get": {
        "tags": [
          "Sections"
        ],
        "parameters": [
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "PageNumber",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "PageSize",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "OrderBy",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "Fields",
            "in": "query",
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Sections"
        ],
        "parameters": [
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/SectionForCreationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections/{id}": {
      "get": {
        "tags": [
          "Sections"
        ],
        "parameters": [
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Sections"
        ],
        "parameters": [
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Sections"
        ],
        "parameters": [
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/SectionForUpdateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Sections"
        ],
        "parameters": [
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments/{enrollmentId}/assignments/{assignmentId}/submissions": {
      "get": {
        "tags": [
          "Submissions"
        ],
        "parameters": [
          {
            "name": "assignmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionParameters"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Submissions"
        ],
        "parameters": [
          {
            "name": "assignmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForCreationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/organizations/{orgId}/courses/{courseId}/sections/{sectionId}/enrollments/{enrollmentId}/assignments/{assignmentId}/submissions/{id}": {
      "get": {
        "tags": [
          "Submissions"
        ],
        "parameters": [
          {
            "name": "assignmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Submissions"
        ],
        "parameters": [
          {
            "name": "assignmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Submissions"
        ],
        "parameters": [
          {
            "name": "assignmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/SubmissionForUpdateDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "patch": {
        "tags": [
          "Submissions"
        ],
        "parameters": [
          {
            "name": "assignmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          },
          {
            "name": "orgId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "courseId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          },
          {
            "name": "enrollmentId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+json": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "text/xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            },
            "application/*+xml": {
              "schema": {
                "type": "array",
                "items": {
                  "$ref": "#/components/schemas/Operation"
                }
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/WeatherForecast": {
      "get": {
        "tags": [
          "WeatherForecast"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/vnd.codemaze.hateoas+json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/vnd.codemaze.apiroot+json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "text/xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/vnd.codemaze.hateoas+xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/vnd.codemaze.apiroot+xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "AssignmentForCreationDto": {
        "required": [
          "description",
          "title"
        ],
        "type": "object",
        "properties": {
          "title": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "description": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "AssignmentForUpdateDto": {
        "required": [
          "description",
          "title"
        ],
        "type": "object",
        "properties": {
          "title": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "description": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "OperationType": {
        "enum": [
          0,
          1,
          2,
          3,
          4,
          5,
          6
        ],
        "type": "integer",
        "format": "int32"
      },
      "Operation": {
        "type": "object",
        "properties": {
          "value": {
            "type": "object",
            "additionalProperties": false,
            "nullable": true
          },
          "operationType": {
            "allOf": [
              {
                "$ref": "#/components/schemas/OperationType"
              }
            ],
            "readOnly": true
          },
          "path": {
            "type": "string",
            "nullable": true
          },
          "op": {
            "type": "string",
            "nullable": true
          },
          "from": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AutUserForRegistrationDto": {
        "required": [
          "password",
          "userName"
        ],
        "type": "object",
        "properties": {
          "firstName": {
            "type": "string",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "nullable": true
          },
          "userName": {
            "type": "string"
          },
          "password": {
            "type": "string"
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "phoneNumber": {
            "type": "string",
            "nullable": true
          },
          "roles": {
            "type": "array",
            "items": {
              "type": "string"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AutUserForAuthenticationDto": {
        "required": [
          "password",
          "userName"
        ],
        "type": "object",
        "properties": {
          "userName": {
            "type": "string"
          },
          "password": {
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "SectionForCreationDto": {
        "required": [
          "createdDate",
          "endDate",
          "startDate",
          "type",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "type": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "format": "date-time"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "CourseForCreationDto": {
        "required": [
          "courseName",
          "createdDate",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "courseName": {
            "maxLength": 10,
            "minLength": 5,
            "type": "string"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          },
          "sections": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SectionForCreationDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CourseForUpdateDto": {
        "required": [
          "courseName",
          "createdDate",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "courseName": {
            "maxLength": 10,
            "minLength": 5,
            "type": "string"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          },
          "sections": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SectionForCreationDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "EnrollmentForCreationDto": {
        "required": [
          "attributeName",
          "createdDate",
          "endDate",
          "startDate",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "attributeName": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "format": "date-time"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "EnrollmentForUpdateDto": {
        "required": [
          "attributeName",
          "createdDate",
          "endDate",
          "startDate",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "attributeName": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "format": "date-time"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "OrganizationForCreationDto": {
        "required": [
          "address",
          "country",
          "orgName"
        ],
        "type": "object",
        "properties": {
          "orgName": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "address": {
            "type": "string"
          },
          "country": {
            "type": "string"
          },
          "courses": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/CourseForCreationDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ProblemDetails": {
        "type": "object",
        "properties": {
          "type": {
            "type": "string",
            "nullable": true
          },
          "title": {
            "type": "string",
            "nullable": true
          },
          "status": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "detail": {
            "type": "string",
            "nullable": true
          },
          "instance": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": {
          "type": "object",
          "additionalProperties": false
        }
      },
      "OrganizationForUpdateDto": {
        "required": [
          "address",
          "country",
          "orgName"
        ],
        "type": "object",
        "properties": {
          "orgName": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "address": {
            "type": "string"
          },
          "country": {
            "type": "string"
          },
          "courses": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/CourseForCreationDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SectionForUpdateDto": {
        "required": [
          "createdDate",
          "endDate",
          "startDate",
          "type",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "type": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "format": "date-time"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "SubmissionParameters": {
        "type": "object",
        "properties": {
          "pageNumber": {
            "type": "integer",
            "format": "int32"
          },
          "pageSize": {
            "type": "integer",
            "format": "int32"
          },
          "orderBy": {
            "type": "string",
            "nullable": true
          },
          "fields": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SubmissionForCreationDto": {
        "required": [
          "createdDate",
          "submissionTitle",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "submissionTitle": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "score": {
            "maximum": 2147483647,
            "minimum": 10,
            "type": "integer",
            "format": "int32"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "SubmissionForUpdateDto": {
        "required": [
          "createdDate",
          "submissionTitle",
          "updatedDate"
        ],
        "type": "object",
        "properties": {
          "submissionTitle": {
            "maxLength": 30,
            "minLength": 5,
            "type": "string"
          },
          "score": {
            "maximum": 2147483647,
            "minimum": 10,
            "type": "integer",
            "format": "int32"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "updatedDate": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "WeatherForecast": {
        "type": "object",
        "properties": {
          "date": {
            "type": "string",
            "format": "date-time"
          },
          "temperatureC": {
            "type": "integer",
            "format": "int32"
          },
          "temperatureF": {
            "type": "integer",
            "format": "int32",
            "readOnly": true
          },
          "summary": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    },
    "securitySchemes": {
      "Bearer": {
        "type": "apiKey",
        "description": "Place to add JWT with Bearer",
        "name": "Authorization",
        "in": "header"
      }
    }
  },
  "security": [
    {
      "Bearer": [ ]
    }
  ]
}


